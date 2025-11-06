using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SurfRater.Core.MathModel.New_Model_Implementation.Models
{
    public class OverpassBeachCollection
    {
        public string Type { get; set; }
        public List<OverpassBeachFeature> Features { get; set; }
    }

    public class OverpassBeachFeature
    {
        public string Type { get; set; }
        public OverpassBeachProperties Properties { get; set; }
        public OverpassBeachGeometry Geometry { get; set; }
    }

    public class OverpassBeachProperties
    {
        public string Name { get; set; }

        [JsonPropertyName("name:en")]
        public string Name_en { get; set; }

        [JsonPropertyName("name:pt")]
        public string Name_pt { get; set; }

        public string Natural { get; set; }
        public string Type { get; set; }
        public string Wikidata { get; set; }
        public string Wikipedia { get; set; }

        [JsonPropertyName("@id")]
        public string Id { get; set; }
    }

    public class OverpassBeachGeometry
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }
}