using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Globalization;
using SurfRater.Core.MathModel.New_Model_Implementation.Models;
using SurfRater.Core.MathModel.New_Model_Implementation.Services;

namespace SurfRater.Core.Tests.MathModel
{
    [TestClass]
    public class LagunaIntegrationTest
    {
        private static readonly HttpClient httpClient = new HttpClient();

        [TestMethod]
        public async Task AvaliarPraiaLagunaComDadosReaisDoOpenMeteo()
        {
            // Caminho para o arquivo de praias
            string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "praias.geojson");
            var beaches = BeachImporter.LoadFromGeoJson(filePath);
            Assert.IsTrue(beaches.Count > 0, "Nenhuma praia foi carregada do GeoJSON.");

            // Coordenadas aproximadas de Laguna, SC
            double targetLat = -28.4825;
            double targetLon = -48.7808;

            // Busca a praia mais próxima dessas coordenadas
            var beach = beaches
                .OrderBy(b => Distancia(b.Latitude, b.Longitude, targetLat, targetLon))
                .FirstOrDefault();

            Assert.IsNotNull(beach, "Nenhuma praia encontrada próxima às coordenadas de Laguna.");

            // Valida coordenadas
            if (Math.Abs(beach.Latitude) > 90 || Math.Abs(beach.Longitude) > 180)
            {
                Assert.Fail($"Coordenadas inválidas para {beach.Name}: {beach.Latitude}, {beach.Longitude}");
            }

            // Monta URL da API com InvariantCulture
            string url = $"https://marine-api.open-meteo.com/v1/marine" +
                         $"?latitude={beach.Latitude.ToString(CultureInfo.InvariantCulture)}" +
                         $"&longitude={beach.Longitude.ToString(CultureInfo.InvariantCulture)}" +
                         $"&hourly=wave_height,wave_direction,wave_period,wind_wave_direction" +
                         $"&timezone=auto";

            System.Console.WriteLine($"Consultando API para {beach.Name}: {url}");

            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var forecast = JsonSerializer.Deserialize<OpenMeteoMarineResponse>(json, options);
            Assert.IsNotNull(forecast, "Resposta da API veio nula.");

            // Usa a primeira hora disponível
            var weatherData = new WeatherData
            {
                Current = new MarineConditions
                {
                    Wave_Height = forecast.Hourly.Wave_Height[0],
                    Wave_Period = forecast.Hourly.Wave_Period[0],
                    Wave_Direction = forecast.Hourly.Wave_Direction[0],
                    Wind_Wave_Direction = forecast.Hourly.Wind_Wave_Direction[0]
                }
            };

            var evaluator = new SurfEvaluatorService();
            var result = evaluator.Evaluate(weatherData, SurfStyle.Longboard, beach);

            System.Console.WriteLine($"Praia: {beach.Name}");
            System.Console.WriteLine($"Estilo: {result.Style}");
            System.Console.WriteLine($"Avaliação: {result.Rating}");
            System.Console.WriteLine($"Comentário: {result.Commentary}");

            Assert.IsNotNull(result.Rating);
        }

        public static double Distancia(double lat1, double lon1, double lat2, double lon2)
        {
            return System.Math.Sqrt(
                System.Math.Pow(lat1 - lat2, 2) +
                System.Math.Pow(lon1 - lon2, 2)
            );
        }
    }
}