namespace SurfRater.Core.Data.ValueObjects;

/// <summary>
/// Represents weather and ocean condition data used for surf rating calculations.
/// </summary>
public class WeatherData
{
    /// <summary>
    /// Location name where the data was collected.
    /// </summary>
    public Coordinate Location { get; set; }

    /// <summary>
    /// The timestamp of the weather data reading.
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Wind speed, typically in km/h or m/s.
    /// </summary>
    public WeigthedObject<double> WindSpeed { get; set; } // velocidade (nós)

    public WeigthedObject<double> Rajada { get; set; }//rajada (nós)

    public WeigthedObject<double> WindDirection { get; set; }//direção do vento (0-360)
    public WeigthedObject<double> WaveHeight { get; set; } //ondulação (m)

    public WeigthedObject<double> WavePeriod { get; set; } //periodo da vaga (s)
    public WeigthedObject<double> WaveDirection { get; set; } //direção da vaga (0-360)

    public WeigthedObject<double> AirTemperature { get; set; } //temperatura (ºC)

    /// <summary>
    /// Water temperature in degrees Celsius.
    /// </summary>
    public WeigthedObject<double> WaterTemperature { get; set; }
}