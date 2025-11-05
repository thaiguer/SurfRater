using SurfRater.Core.Data.ValueObjects;
using SurfRater.Core.MathModel.Interfaces;

namespace SurfRater.Core.MathModel.Implementation;

public class SurfConditonsCalculator : ISurfConditonsCalculator
{
    public WeatherData WeatherData { get; set; }
    public double Result { get; private set; }

    public SurfConditonsCalculator(WeatherData weatherData)
    {
        WeatherData = weatherData;
    }

    public string Calculate(List<SurfParameter> surfParameters)
    {
        double result = 1;
        
        foreach(var surfParameter in surfParameters)
        {
            result = ((surfParameter.ForecastValue / surfParameter.IdealValue) + result) / 2;
        }

        string condition;

        switch (result)
        {
            case > 1.5:
                condition = "tá muito alto";
                break;
            case > 1.2:
                condition = "tá pra onda boa";
                break;
            case > 1.0:
                condition = "tá picaaaaaaaaaaaaaa";
                break;
            case > 0.75:
                condition = "tá quase bom";
                break;
            case > 0.5:
                condition = "tá normal";
                break;
            default:
                condition = "tá fraco";
                break;
        }

        return condition;
    }

}