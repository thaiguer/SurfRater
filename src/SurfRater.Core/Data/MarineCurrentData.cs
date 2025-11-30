namespace SurfRater.Core.Data;

public class Current
{
    public string Time { get; set; }
    public int Interval { get; set; }
    public double Wave_Height { get; set; }
    public double Wave_Direction { get; set; } //direção da vaga
    public double Wind_Wave_Direction { get; set; }
}
