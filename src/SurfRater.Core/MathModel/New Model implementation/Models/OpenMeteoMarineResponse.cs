using System.Collections.Generic;

namespace SurfRater.Core.MathModel.New_Model_Implementation.Models
{
    public class OpenMeteoMarineResponse
    {
        public HourlyData Hourly { get; set; }
    }

    public class HourlyData
    {
        public List<double> Wave_Height { get; set; }
        public List<int> Wave_Direction { get; set; }
        public List<double> Wave_Period { get; set; }
        public List<int> Wind_Wave_Direction { get; set; }
    }
}
