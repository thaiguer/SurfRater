using System.Collections.Generic;

namespace SurfRater.Core.MathModel.New_Model_Implementation.Models
{
    public class BeachProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Orientation { get; set; }
        public string BottomType { get; set; }
        public List<int> PreferredSwellDirections { get; set; }
        public List<SurfStyle> RecommendedStyles { get; set; }
    }
}