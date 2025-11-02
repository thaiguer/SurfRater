namespace SurfRater.Core.Data.Implementation.OpenMeteo;

public class HourlyData
{
    public List<string> Time { get; set; }
    public List<double> SwellWaveHeight { get; set; }
    public List<int> SwellWaveDirection { get; set; }
    public List<double> WaveHeight { get; set; }
    public List<int> WaveDirection { get; set; }
    public List<double> WavePeriod { get; set; }
    public List<double> SwellWavePeriod { get; set; }
    public List<double?> SwellWavePeakPeriod { get; set; }
    public List<int> WindWaveDirection { get; set; }
    public List<double> WindWaveHeight { get; set; }
}