namespace SurfRater.Core.MathModel.New_Model_Implementation.Models
{
    public class WeatherData
    {
        public MarineConditions Current { get; set; }
    }

    public class MarineConditions
    {
        public double Wave_Height { get; set; }
        public double Wave_Period { get; set; }
        public int Wave_Direction { get; set; }
        public int Wind_Wave_Direction { get; set; }
    }
}