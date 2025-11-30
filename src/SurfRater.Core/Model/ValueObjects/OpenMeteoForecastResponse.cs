using System.Text.Json.Serialization;

namespace SurfRater.Core.Model.ValueObjects;

public class OpenMeteoForecastResponse
{
    [JsonPropertyName("hourly")]
    public ForecastHourlyData Hourly { get; set; }
}

public class ForecastHourlyData
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public List<double?> Wind_Speed_10m { get; set; }

    [JsonPropertyName("wind_direction_10m")]
    public List<int?> Wind_Direction_10m { get; set; }
}