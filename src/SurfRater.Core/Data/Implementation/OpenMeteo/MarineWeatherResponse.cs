namespace SurfRater.Core.Data.Implementation.OpenMeteo;

public class MarineWeatherResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double GenerationtimeMs { get; set; }
    public int UtcOffsetSeconds { get; set; }
    public string Timezone { get; set; }
    public string TimezoneAbbreviation { get; set; }
    public double Elevation { get; set; }
    public MarineCurrentUnits CurrentUnits { get; set; }
    public MarineCurrentData Current { get; set; }
}
