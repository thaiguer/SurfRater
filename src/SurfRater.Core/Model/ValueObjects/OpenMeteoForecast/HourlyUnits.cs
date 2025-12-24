using System.Text.Json.Serialization;

namespace SurfRater.Core.Model.ValueObjects.OpenMeteoForecast;

public class HourlyUnits
{
    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("temperature_2m")]
    public string Temperature2m { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public string WindSpeed10m { get; set; }

    [JsonPropertyName("wind_direction_10m")]
    public string WindDirection10m { get; set; }

    [JsonPropertyName("rain")]
    public string Rain { get; set; }

    [JsonPropertyName("wind_gusts_10m")]
    public string WindGusts10m { get; set; }
}