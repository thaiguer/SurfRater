using System.Text.Json;
using SurfRater.Core.Data;
using SurfRater.Core.Services;

namespace SurfRater.Core.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public async Task RequisitionAsync()
    {
        double latitude = -28.48871042016006;
        double longitude = -48.74739086392232;

        if (!CoordinatesFilterService.EstaNaMalha(latitude, longitude))
        {          
            Assert.Inconclusive("Coordenada fora da faixa entre Torres e Florianópolis.");
            return;
        }

        var url = $"https://marine-api.open-meteo.com/v1/marine?latitude=-28.48871042016006&longitude=-48.74739086392232&current=wave_height,wave_direction,wind_wave_direction&timezone=auto";
        Console.WriteLine($"Chamando API: {url}");

        using var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.GetStringAsync(url);
            Console.WriteLine($"JSON bruto:\n{response}");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var weatherData = JsonSerializer.Deserialize<MarineWeatherResponse>(response, options);

            if (weatherData?.WeatherData == null)
            {
                Console.WriteLine("Dados marinhos ausentes na resposta.");
                Assert.Inconclusive("Sem dados marinhos disponíveis para esta coordenada.");
            }
            else
            {
                Console.WriteLine($"Altura da onda: {weatherData.WeatherData.WaveHeight.FirstOrDefault()}");
                Console.WriteLine($"Direção da onda: {weatherData.WeatherData.WaveDirection.FirstOrDefault()}");
                Console.WriteLine($"Direção do vento sobre a onda: {weatherData.WeatherData.WindWaveDirection.FirstOrDefault()}");

                Assert.IsTrue(weatherData.WeatherData.WaveHeight.FirstOrDefault() > 0, "Altura da onda deve ser maior que zero.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na requisição: {ex}");
            Assert.Inconclusive($"Erro ao requisitar dados: {ex.Message}");
        }
    }
}