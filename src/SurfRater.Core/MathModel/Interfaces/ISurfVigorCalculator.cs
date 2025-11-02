using SurfRater.Core.Data.ValueObjects;

namespace SurfRater.Core.MathModel.Interfaces;

interface ISurfConditonsCalculator
{
    WeatherData WeatherData { get; set; }
    double Result { get; }
    void Calculate();
}