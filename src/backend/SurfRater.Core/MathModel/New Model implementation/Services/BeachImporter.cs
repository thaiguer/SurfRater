using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SurfRater.Core.MathModel.New_Model_Implementation.Models;

namespace SurfRater.Core.MathModel.New_Model_Implementation.Services
{
    public static class BeachImporter
    {
        /// <summary>
        /// Lê um arquivo GeoJSON exportado do Overpass Turbo e converte em uma lista de BeachProfile.
        /// </summary>
        /// <param name="filePath">Caminho para o arquivo .geojson</param>
        /// <returns>Lista de BeachProfile</returns>
        public static List<BeachProfile> LoadFromGeoJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Arquivo não encontrado: {filePath}");

            var json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var geoData = JsonSerializer.Deserialize<OverpassBeachCollection>(json, options);

            if (geoData?.Features == null || geoData.Features.Count == 0)
                throw new InvalidOperationException("O arquivo GeoJSON não contém 'features'. Verifique se exportou no formato correto (GeoJSON).");

            var beaches = new List<BeachProfile>();

            foreach (var feature in geoData.Features)
            {
                // Verifica se tem nome e coordenadas
                if (feature.Geometry?.Type == "Point" &&
                    feature.Properties?.Name != null &&
                    feature.Geometry.Coordinates?.Count == 2)
                {
                    beaches.Add(new BeachProfile
                    {
                        Name = feature.Properties.Name,
                        Latitude = feature.Geometry.Coordinates[1], // latitude
                        Longitude = feature.Geometry.Coordinates[0], // longitude
                        Orientation = 180, // valor padrão, pode ser calculado depois
                        BottomType = feature.Properties?.Natural ?? "areia", // usa 'natural' se existir
                        PreferredSwellDirections = new List<int> { 160, 170, 180 },
                        RecommendedStyles = new List<SurfStyle> { SurfStyle.Longboard, SurfStyle.Bodyboard }
                    });
                }
            }

            return beaches;
        }
    }
}