using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using SurfRater.Core.MathModel.New_Model_Implementation.Models;
using SurfRater.Core.MathModel.New_Model_Implementation.Services;

namespace SurfRater.Core.Tests.MathModel
{
    [TestClass]
    public class SurfEvaluationIntegrationTests
    {
        private static readonly HttpClient httpClient = new HttpClient();

        [TestMethod]
        public async Task AvaliarPraiasComDadosReaisDoOpenMeteo()
        {
            // Caminho robusto para o arquivo
            string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "praias.geojson");

            var beaches = BeachImporter.LoadFromGeoJson(filePath);
            Assert.IsTrue(beaches.Count > 0, "Nenhuma praia foi carregada do GeoJSON.");

            var evaluator = new SurfEvaluatorService();

            foreach (var beach in beaches)
            {
                // Ignora coordenadas inválidas
                if (Math.Abs(beach.Latitude) > 90 || Math.Abs(beach.Longitude) > 180)
                {
                    System.Console.WriteLine($"Ignorando praia {beach.Name} com coordenadas inválidas.");
                    continue;
                }

                // Monta URL da API
                string url = $"https://marine-api.open-meteo.com/v1/marine" +
                             $"?latitude={beach.Latitude}" +
                             $"&longitude={beach.Longitude}" +
                             $"&hourly=wave_height,wave_direction,wave_period,wind_wave_direction" +
                             $"&timezone=auto";

                System.Console.WriteLine($"Consultando API para {beach.Name}: {url}");

                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine($"Falha na API para {beach.Name}: {response.StatusCode}");
                    continue; // não quebra o teste, apenas ignora essa praia
                }

                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var forecast = JsonSerializer.Deserialize<OpenMeteoMarineResponse>(json, options);

                Assert.IsNotNull(forecast, $"Resposta nula da API para {beach.Name}");

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

                var result = evaluator.Evaluate(weatherData, SurfStyle.Longboard, beach);

                System.Console.WriteLine($"Praia: {beach.Name}");
                System.Console.WriteLine($"Estilo: {result.Style}");
                System.Console.WriteLine($"Avaliação: {result.Rating}");
                System.Console.WriteLine($"Comentário: {result.Commentary}");

                Assert.IsNotNull(result.Rating);
            }
        }
    }

    // Modelo simplificado para resposta do Open-Meteo
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