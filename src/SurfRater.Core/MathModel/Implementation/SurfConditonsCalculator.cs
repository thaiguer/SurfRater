using SurfRater.Core.Data.Interfaces;
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

    public void Calculate()
    {
        if (WeatherData == null)
        Result = WeatherData.WindSpeed * 0.8 + WeatherData.WaveHeight * 1.2;
    }
}