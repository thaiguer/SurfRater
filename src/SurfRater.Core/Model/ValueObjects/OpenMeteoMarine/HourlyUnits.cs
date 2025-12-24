using System.Text.Json.Serialization;

namespace SurfRater.Core.Model.ValueObjects.OpenMeteoMarine;

public class HourlyUnits
{
    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("wave_height")]
    public string WaveHeight { get; set; }

    [JsonPropertyName("wave_direction")]
    public string WaveDirection { get; set; }

    [JsonPropertyName("wave_period")]
    public string WavePeriod { get; set; }
}