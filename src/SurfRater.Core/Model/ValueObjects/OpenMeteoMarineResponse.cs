namespace SurfRater.Core.Model.ValueObjects;

public class OpenMeteoMarineResponse
{
    public HourlyData Hourly { get; set; }
}

public class HourlyData
{
    public List<string> Time { get; set; }
    public List<double> Wave_Height { get; set; }
    public List<int> Wave_Direction { get; set; }
    public List<double> Wave_Period { get; set; }
    public List<int> Wind_Wave_Direction { get; set; }
}