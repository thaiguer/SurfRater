using System.Text.Json.Serialization;

namespace SurfRater.Core.Data;

public class MarineWeatherResponse
{
    [JsonPropertyName("hourly")]
    public Hourly WeatherData { get; set; }
}

public class Hourly
{
    [JsonPropertyName("wind_wave_direction")]
    public List<double> WindWaveDirection { get; set; }

    [JsonPropertyName("wave_height")]
    public List<double> WaveHeight { get; set; }

    [JsonPropertyName("wave_direction")]
    public List<double> WaveDirection { get; set; }
}