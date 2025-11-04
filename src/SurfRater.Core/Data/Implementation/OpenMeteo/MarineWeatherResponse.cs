namespace SurfRater.Core.Data.Implementation.OpenMeteo;

public class MarineWeatherResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Generationtime_Ms { get; set; }
    public int Utc_Off_setSeconds { get; set; }
    public string Timezone { get; set; }
    public string Timezone_abbreviation { get; set; }
    public double Elevation { get; set; }
    public Current_Units Current_Units { get; set; }
    public List<double> wave_height { get; set; }
    //public MarineCurrentData Current { get; set; }
}
