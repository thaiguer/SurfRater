using SurfRater.Core.Model.Entities;

namespace SurfRater.Core.Model.ValueObjects;

public class OneHourForecast : ValueObject
{
    public OneHourForecast(
        string time,
        double temperature2m,
        double windSpeed10m,
        int windDirection10m,
        double rain,
        double windGusts10m,
        double waveHeight,
        int waveDirection,
        double wavePeriod)
    {
        Time = DateTime.Parse(time);
        Temperature2m = new SurfParameterValue(temperature2m, 0);
        WindSpeed10m = new SurfParameterValue(windSpeed10m, 0);
        WindDirection10m = new SurfParameterValue(windDirection10m, 0);
        Rain = new SurfParameterValue(rain, 0);
        WindGusts10m = new SurfParameterValue(windGusts10m, 0);
        WaveHeight = new SurfParameterValue(waveHeight, 0);
        WaveDirection = new SurfParameterValue(waveDirection, 0);
        WavePeriod = new SurfParameterValue(wavePeriod, 0);
    }

    public DateTime Time { get; }
    public SurfParameterValue Temperature2m { get; }
    public SurfParameterValue WindSpeed10m { get; }
    public SurfParameterValue WindDirection10m { get; }
    public SurfParameterValue Rain { get; }
    public SurfParameterValue WindGusts10m { get; }
    public SurfParameterValue WaveHeight { get; }
    public SurfParameterValue WaveDirection { get; }
    public SurfParameterValue WavePeriod { get; }
}