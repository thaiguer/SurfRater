using System.Text.Json.Serialization;

namespace SurfRater.Core.Model.ValueObjects.OpenMeteoMarine;

public class Hourly
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; }

    [JsonPropertyName("wave_height")]
    public List<double> WaveHeight { get; set; }

    [JsonPropertyName("wave_direction")]
    public List<int> WaveDirection { get; set; }

    [JsonPropertyName("wave_period")]
    public List<double> WavePeriod { get; set; }
}