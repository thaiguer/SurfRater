using System.Collections.Generic;

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
        // Campos básicos
        public string Name { get; set; }

        // Campos multilíngues
        public string Name_en { get; set; }
        public string Name_pt { get; set; }

        // Campos extras do OSM
        public string Natural { get; set; }
        public string Type { get; set; }
        public string Wikidata { get; set; }
        public string Wikipedia { get; set; }

        // Id interno do OSM
        public string Id { get; set; }
    }

    public class OverpassBeachGeometry
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }
}