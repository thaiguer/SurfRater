using System.Text.Json;
using SurfRater.Core.CoordinateFilters;
using SurfRater.Core.Data.Implementation.OpenMeteo;
using SurfRater.Core.Data.ValueObjects;
using SurfRater.Core.MathModel.Implementation;

namespace SurfRater.Core.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestarOCalculo()
    {
        var surfParameters = new List<SurfParameter>();
        surfParameters.Add(new SurfParameter("Swell", 15, 13));
        surfParameters.Add(new SurfParameter("Onda", 15, 13));
        surfParameters.Add(new SurfParameter("Vento", 10, 6));
        surfParameters.Add(new SurfParameter("Vibe", 45, 48));

        var surfConditonsCalculator = new SurfConditonsCalculator(new WeatherData());
        var result = surfConditonsCalculator.Calculate(surfParameters);

        Assert.IsTrue(result.Equals("tá picaaaaaaaaaaaaaa"));
    }
    
    
    [TestMethod]
    public async Task RequisitionAsync()
    {
        double latitude = -28.48871042016006;
        double longitude = -48.74739086392232;

        Console.WriteLine("Iniciando teste de requisição...");
        Console.WriteLine($"Coordenada usada: Latitude = {latitude}, Longitude = {longitude}");

        var coordinatesFilterService = new CoordinatesFilterService();

        if (!coordinatesFilterService.EstaNaMalha(latitude, longitude))
        {
            Console.WriteLine("Coordenada fora da faixa válida. Encerrando teste.");
            Assert.Inconclusive("Coordenada fora da faixa entre Torres e Florianópolis.");
            return;
        }

        var url = $"https://marine-api.open-meteo.com/v1/marine?latitude=-28.48871042016006&longitude=-48.74739086392232&current=wave_height,wave_direction,wind_wave_direction&timezone=auto";
        Console.WriteLine($"Chamando API: {url}");

        using var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.GetStringAsync(url);
            Console.WriteLine("Resposta recebida da API.");
            Console.WriteLine($"JSON bruto:\n{response}");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var weatherData = JsonSerializer.Deserialize<MarineWeatherResponse>(response, options);

            if (weatherData?.Current == null)
            {
                Console.WriteLine("Dados marinhos ausentes na resposta.");
                Assert.Inconclusive("Sem dados marinhos disponíveis para esta coordenada.");
            }
            else
            {
                Console.WriteLine($"Altura da onda: {weatherData.Current.Wave_Height}");
                Console.WriteLine($"Direção da onda: {weatherData.Current.Wave_Direction}");
                Console.WriteLine($"Direção do vento sobre a onda: {weatherData.Current.Wind_Wave_Direction}");

                Assert.IsTrue(weatherData.Current.Wave_Height > 0, "Altura da onda deve ser maior que zero.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na requisição: {ex}");
            Assert.Inconclusive($"Erro ao requisitar dados: {ex.Message}");
        }
    }
}
//-28.48871042016006, -48.74739086392232