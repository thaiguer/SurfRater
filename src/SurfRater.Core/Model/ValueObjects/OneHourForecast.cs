using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Core.Model.Entities;

namespace SurfRater.Core.Model.ValueObjects;

public class OneHourForecast : ObservableObject
{
    public OneHourForecast(
        string time,
        double temperature2m,
        double windSpeed10m,
        double windDirection10m,
        double rain,
        double windGusts10m,
        double waveHeight,
        double waveDirection,
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

    public string Temperature2mToText
    {
        get
        {
            return $"Temperature: {Temperature2m.CurrentValue}";
        }
    }

    public string WindSpeed10mToText
    {
        get
        {
            return $"Wind Speed: {WindSpeed10m.CurrentValue}";
        }
    }

    public string WindDirection10mToText
    {
        get
        {
            return $"Wind Direction: {WindDirection10m.CurrentValue}";
        }
    }

    public string RainToText
    {
        get
        {
            return $"Rain: {Rain.CurrentValue}";
        }
    }

    public string WindGusts10mToText
    {
        get
        {
            return $"Wind Gusts: {WindGusts10m.CurrentValue}";
        }
    }

    public string WaveHeightToText
    {
        get
        {
            return $"Wave Height: {WaveHeight.CurrentValue}";
        }
    }

    public string WaveDirectionToText
    {
        get
        {
            return $"Wave Direction: {WaveDirection.CurrentValue}";
        }
    }

    public string WavePeriodToText
    {
        get
        {
            return $"Wave Period: {WavePeriod.CurrentValue}";
        }
    }
}