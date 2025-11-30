using SurfRater.Core.Enumerators;
using SurfRater.Core.MathModel.New_Model_Implementation.Models;

namespace SurfRater.Core.MathModel.New_Model_Implementation.Services;

public class SurfEvaluatorService
{
    public SurfEvaluationResult Evaluate(WeatherData weatherData, SurfStyle style, BeachProfile beach)
    {
        // Provide default values for nullable properties to avoid errors
        var waveHeight = weatherData.Current.Wave_Height ?? 0;
        var wavePeriod = weatherData.Current.Wave_Period ?? 0;
        var windSpeed = weatherData.Current.Wind_Speed_10m ?? 0;
        var windDirection = weatherData.Current.Wind_Direction_10m ?? 0;
        var swellDirection = weatherData.Current.Wave_Direction ?? 0;

        // Determine wind effect based on beach orientation
        var windEffect = GetWindEffect(windDirection, beach.Orientation);

        // Check if the primary swell direction is aligned with the beach
        bool swellIsAligned = beach.PreferredSwellDirections.Contains(swellDirection);

        SurfEvaluationResult result;

        switch (style)
        {
            case SurfStyle.Bodyboard:
                result = EvaluateBodyboard(waveHeight, wavePeriod, windEffect, windSpeed);
                break;
            case SurfStyle.Longboard:
                result = EvaluateLongboard(waveHeight, wavePeriod, windEffect, windSpeed);
                break;
            case SurfStyle.StandUpPaddle:
                result = EvaluateSUP(waveHeight, windSpeed);
                break;
            case SurfStyle.KiteSurf:
                result = EvaluateKite(windEffect, windSpeed);
                break;
            case SurfStyle.Shortboard:
                result = EvaluateShortboard(waveHeight, wavePeriod, windEffect, windSpeed);
                break;
            case SurfStyle.TowIn:
            case SurfStyle.BigWave:
                result = EvaluateBigWave(waveHeight, wavePeriod, windEffect, windSpeed);
                break;
            case SurfStyle.Foil:
                result = EvaluateFoil(waveHeight, wavePeriod, windEffect, windSpeed);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(style), "Unsupported surf style.");
        }

        // Downgrade rating if swell is not aligned
        if (!swellIsAligned)
        {
            result.Rating = "Ruim";
            result.Commentary += " (Swell desalinhado)";
        }

        return result;
    }

    private WindEffect GetWindEffect(int windDirection, int beachOrientation)
    {
        // Normalize the angle difference to be between -180 and 180
        var angleDifference = (windDirection - beachOrientation + 180 + 360) % 360 - 180;

        if (Math.Abs(angleDifference) > 135) // +/- 45 degrees from direct offshore
        {
            return WindEffect.Offshore; // Terral
        }
        if (Math.Abs(angleDifference) < 45) // +/- 45 degrees from direct onshore
        {
            return WindEffect.Onshore; // Maral
        }
        return WindEffect.CrossShore; // Lateral
    }

    private SurfEvaluationResult CreateResult(SurfStyle style, string rating, string commentary)
    {
        return new SurfEvaluationResult { Style = style, Rating = rating, Commentary = commentary };
    }

    // --- Evaluation Methods ---

    private SurfEvaluationResult EvaluateBodyboard(double h, double p, WindEffect wind, double ws)
    {
        if (wind == WindEffect.Onshore && ws > 15) return CreateResult(SurfStyle.Bodyboard, "Ruim", "Vento maral forte estragando as ondas.");
        if (h >= 1.0 && p >= 7) return CreateResult(SurfStyle.Bodyboard, "Excelente", "Ondas cavadas e fortes, ideais para bodyboard.");
        if (h >= 0.5 && p >= 6) return CreateResult(SurfStyle.Bodyboard, "Moderado", "Condições razoáveis para praticar.");
        return CreateResult(SurfStyle.Bodyboard, "Ruim", "Ondas muito pequenas ou fracas.");
    }

    private SurfEvaluationResult EvaluateLongboard(double h, double p, WindEffect wind, double ws)
    {
        if (wind == WindEffect.Onshore && ws > 12) return CreateResult(SurfStyle.Longboard, "Ruim", "Vento maral forte deixando o mar mexido.");
        if (h >= 0.5 && h <= 1.8 && p >= 9) return CreateResult(SurfStyle.Longboard, "Excelente", "Ondas longas e suaves, perfeitas para caminhar na prancha.");
        if (h >= 0.4 && p >= 8) return CreateResult(SurfStyle.Longboard, "Moderado", "Condições aceitáveis para longboard.");
        return CreateResult(SurfStyle.Longboard, "Ruim", "Ondas curtas, fracas ou mexidas.");
    }

    private SurfEvaluationResult EvaluateSUP(double h, double ws)
    {
        if (h <= 0.4 && ws < 10) return CreateResult(SurfStyle.StandUpPaddle, "Excelente", "Mar calmo e pouco vento, ideal para remada no SUP.");
        if (h <= 0.8 && ws < 15) return CreateResult(SurfStyle.StandUpPaddle, "Moderado", "Um pouco de onda e vento, mas remável.");
        return CreateResult(SurfStyle.StandUpPaddle, "Ruim", "Mar muito agitado ou vento forte.");
    }

    private SurfEvaluationResult EvaluateKite(WindEffect wind, double ws)
    {
        if (wind == WindEffect.CrossShore && ws >= 20 && ws <= 45) return CreateResult(SurfStyle.KiteSurf, "Excelente", "Vento lateral na medida certa para o kite.");
        if (wind != WindEffect.Onshore && ws >= 15) return CreateResult(SurfStyle.KiteSurf, "Moderado", "Vento bom, mas direção pode não ser a ideal.");
        return CreateResult(SurfStyle.KiteSurf, "Ruim", "Vento fraco, maral ou muito forte.");
    }

    private SurfEvaluationResult EvaluateShortboard(double h, double p, WindEffect wind, double ws)
    {
        if (wind == WindEffect.Onshore && ws > 15) return CreateResult(SurfStyle.Shortboard, "Ruim", "Vento maral forte estragando a formação.");
        if (h >= 1.2 && h <= 3.0 && p >= 8) return CreateResult(SurfStyle.Shortboard, "Excelente", "Ondas fortes e rápidas, perfeitas para manobras.");
        if (h >= 0.8 && p >= 7) return CreateResult(SurfStyle.Shortboard, "Moderado", "Condições razoáveis para treinar.");
        return CreateResult(SurfStyle.Shortboard, "Ruim", "Ondas fracas ou mexidas.");
    }

    private SurfEvaluationResult EvaluateBigWave(double h, double p, WindEffect wind, double ws)
    {
        string styleName = h >= 6.0 ? "BigWave" : "TowIn";
        var styleEnum = h >= 6.0 ? SurfStyle.BigWave : SurfStyle.TowIn;

        if (wind == WindEffect.Onshore && ws > 25) return CreateResult(styleEnum, "Ruim", $"Vento maral muito forte torna as ondas perigosas e ruins para {styleName}.");
        if (h >= 5.0 && p >= 12) return CreateResult(styleEnum, "Excelente", $"Condições extremas e desafiadoras, ideal para {styleName}.");
        if (h >= 3.5 && p >= 10) return CreateResult(styleEnum, "Moderado", "Ondas grandes, mas não gigantes. Bom para treino.");
        return CreateResult(styleEnum, "Ruim", "Ondas insuficientes para a modalidade.");
    }

    private SurfEvaluationResult EvaluateFoil(double h, double p, WindEffect wind, double ws)
    {
        if (wind == WindEffect.Onshore && ws > 15) return CreateResult(SurfStyle.Foil, "Ruim", "Vento maral forte dificulta o controle do foil.");
        if (h >= 0.4 && h <= 1.5 && p >= 9) return CreateResult(SurfStyle.Foil, "Excelente", "Ondulação suave e longa, perfeita para voar com o foil.");
        if (h >= 0.3 && p >= 8) return CreateResult(SurfStyle.Foil, "Moderado", "Condições razoáveis para a prática de foil.");
        return CreateResult(SurfStyle.Foil, "Ruim", "Sem ondulação suficiente ou mar muito mexido.");
    }
}