using System.Text.Json.Serialization;

namespace SurfRater.Core.Model.ValueObjects.OpenMeteoForecast;

public class Hourly
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; }

    [JsonPropertyName("temperature_2m")]
    public List<double> Temperature2m { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public List<double> WindSpeed10m { get; set; }

    [JsonPropertyName("wind_direction_10m")]
    public List<double> WindDirection10m { get; set; }

    [JsonPropertyName("rain")]
    public List<double> Rain { get; set; }

    [JsonPropertyName("wind_gusts_10m")]
    public List<double> WindGusts10m { get; set; }
}