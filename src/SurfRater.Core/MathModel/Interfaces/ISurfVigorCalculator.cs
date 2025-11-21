using SurfRater.Core.Data.ValueObjects;
using SurfRater.Core.MathModel.Implementation;

namespace SurfRater.Core.MathModel.Interfaces;

interface ISurfConditonsCalculator
{
    WeatherData WeatherData { get; set; }
    double Result { get; }
    string Calculate(List<SurfParameter> surfParameters);
}