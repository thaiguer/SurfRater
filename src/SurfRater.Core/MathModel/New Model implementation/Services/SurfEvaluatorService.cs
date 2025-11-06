using System;
using System.Collections.Generic;
using SurfRater.Core.MathModel.New_Model_Implementation.Models;

namespace SurfRater.Core.MathModel.New_Model_Implementation.Services
{
    public class SurfEvaluatorService : ISurfEvaluatorService
    {
        public SurfEvaluationResult Evaluate(WeatherData weatherData, SurfStyle style, BeachProfile beach)
        {
            var waveHeight = weatherData.Current.Wave_Height;
            var wavePeriod = weatherData.Current.Wave_Period;
            var windDirection = weatherData.Current.Wind_Wave_Direction;
            var swellDirection = weatherData.Current.Wave_Direction;

            bool swellIsAligned = beach.PreferredSwellDirections.Contains(swellDirection);

            SurfEvaluationResult result;

            switch (style)
            {
                case SurfStyle.Bodyboard:
                    result = EvaluateBodyboard(waveHeight, wavePeriod);
                    break;
                case SurfStyle.Longboard:
                    result = EvaluateLongboard(waveHeight, wavePeriod);
                    break;
                case SurfStyle.StandUpPaddle:
                    result = EvaluateSUP(waveHeight, windDirection);
                    break;
                case SurfStyle.KiteSurf:
                    result = EvaluateKite(windDirection, waveHeight);
                    break;
                case SurfStyle.Shortboard:
                    result = EvaluateShortboard(waveHeight, wavePeriod);
                    break;
                case SurfStyle.TowIn:
                    result = EvaluateTowIn(waveHeight, wavePeriod, windDirection);
                    break;
                case SurfStyle.Foil:
                    result = EvaluateFoil(waveHeight, wavePeriod, windDirection);
                    break;
                case SurfStyle.BigWave:
                    result = EvaluateBigWave(waveHeight, wavePeriod, windDirection);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(style), "Unsupported surf style.");
            }

            if (!swellIsAligned)
            {
                result.Rating = "Ruim";
                result.Commentary += " (swell desalinhado com a praia)";
            }

            return result;
        }

        // ---------------- MÉTODOS DE AVALIAÇÃO ----------------

        private SurfEvaluationResult EvaluateBodyboard(double waveHeight, double wavePeriod)
        {
            if (waveHeight >= 1.0 && wavePeriod >= 8)
                return new SurfEvaluationResult { Style = SurfStyle.Bodyboard, Rating = "Excelente", Commentary = "Ondas fortes e curtas, ideais para manobras rápidas." };
            if (waveHeight >= 0.5)
                return new SurfEvaluationResult { Style = SurfStyle.Bodyboard, Rating = "Moderado", Commentary = "Ondas razoáveis para treino." };
            return new SurfEvaluationResult { Style = SurfStyle.Bodyboard, Rating = "Ruim", Commentary = "Ondas fracas para bodyboard." };
        }

        private SurfEvaluationResult EvaluateLongboard(double waveHeight, double wavePeriod)
        {
            if (waveHeight >= 0.6 && wavePeriod >= 10)
                return new SurfEvaluationResult { Style = SurfStyle.Longboard, Rating = "Excelente", Commentary = "Ondas longas e suaves, perfeitas para longboard." };
            if (waveHeight >= 0.4)
                return new SurfEvaluationResult { Style = SurfStyle.Longboard, Rating = "Moderado", Commentary = "Condições aceitáveis para longboard." };
            return new SurfEvaluationResult { Style = SurfStyle.Longboard, Rating = "Ruim", Commentary = "Ondas curtas e fracas." };
        }

        private SurfEvaluationResult EvaluateSUP(double waveHeight, int windDirection)
        {
            if (waveHeight <= 0.5 && (windDirection < 90 || windDirection > 270))
                return new SurfEvaluationResult { Style = SurfStyle.StandUpPaddle, Rating = "Excelente", Commentary = "Mar calmo e pouco vento, ideal para SUP." };
            return new SurfEvaluationResult { Style = SurfStyle.StandUpPaddle, Rating = "Ruim", Commentary = "Ondas agitadas ou vento forte dificultam o SUP." };
        }

        private SurfEvaluationResult EvaluateKite(int windDirection, double waveHeight)
        {
            if (windDirection >= 90 && windDirection <= 270 && waveHeight <= 1.0)
                return new SurfEvaluationResult { Style = SurfStyle.KiteSurf, Rating = "Excelente", Commentary = "Vento lateral e mar estável, ótimo para kite." };
            return new SurfEvaluationResult { Style = SurfStyle.KiteSurf, Rating = "Ruim", Commentary = "Vento fraco ou instável, não recomendado para kite." };
        }

        private SurfEvaluationResult EvaluateShortboard(double waveHeight, double wavePeriod)
        {
            if (waveHeight >= 1.2 && wavePeriod >= 8)
                return new SurfEvaluationResult { Style = SurfStyle.Shortboard, Rating = "Excelente", Commentary = "Ondas fortes e rápidas, perfeitas para manobras radicais." };
            if (waveHeight >= 0.8)
                return new SurfEvaluationResult { Style = SurfStyle.Shortboard, Rating = "Moderado", Commentary = "Condições razoáveis para shortboard." };
            return new SurfEvaluationResult { Style = SurfStyle.Shortboard, Rating = "Ruim", Commentary = "Ondas fracas para prancha curta." };
        }

        private SurfEvaluationResult EvaluateTowIn(double waveHeight, double wavePeriod, int windDirection)
        {
            if (waveHeight >= 4.0 && wavePeriod >= 12)
                return new SurfEvaluationResult { Style = SurfStyle.TowIn, Rating = "Excelente", Commentary = "Condições extremas, ideais para surf rebocado." };
            if (waveHeight >= 3.0)
                return new SurfEvaluationResult { Style = SurfStyle.TowIn, Rating = "Moderado", Commentary = "Ondas grandes, mas abaixo do ideal para tow-in." };
            return new SurfEvaluationResult { Style = SurfStyle.TowIn, Rating = "Ruim", Commentary = "Ondas insuficientes para surf rebocado." };
        }

        private SurfEvaluationResult EvaluateFoil(double waveHeight, double wavePeriod, int windDirection)
        {
            if (waveHeight >= 0.4 && waveHeight <= 1.0 && wavePeriod >= 10 && windDirection < 90)
                return new SurfEvaluationResult { Style = SurfStyle.Foil, Rating = "Excelente", Commentary = "Ondas suaves e contínuas, perfeitas para foil surf." };
            return new SurfEvaluationResult { Style = SurfStyle.Foil, Rating = "Ruim", Commentary = "Condições instáveis para foil surf." };
        }

        private SurfEvaluationResult EvaluateBigWave(double waveHeight, double wavePeriod, int windDirection)
        {
            if (waveHeight >= 6.0 && wavePeriod >= 15 && (windDirection < 90 || windDirection > 270))
                return new SurfEvaluationResult { Style = SurfStyle.BigWave, Rating = "Excelente", Commentary = "Condições épicas para quem busca adrenalina em ondas gigantes." };
            if (waveHeight >= 5.0)
                return new SurfEvaluationResult { Style = SurfStyle.BigWave, Rating = "Moderado", Commentary = "Ondas grandes, mas com vento desfavorável." };
            return new SurfEvaluationResult { Style = SurfStyle.BigWave, Rating = "Ruim", Commentary = "Ondas abaixo do ideal para big wave surf." };
        }
    }
}