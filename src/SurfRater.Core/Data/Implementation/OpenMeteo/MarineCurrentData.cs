namespace SurfRater.Core.Data.Implementation.OpenMeteo;

public class MarineCurrentData
{
    public string Time { get; set; }
    public int Interval { get; set; }
    public double WaveHeight { get; set; }
    public double WaveDirection { get; set; }
    public double WindWaveDirection { get; set; }
}
