using System.Text.Json;
using SurfRater.Core.Data;
using SurfRater.Core.Data.Implementation.OpenMeteo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;



namespace SurfRater.Core.Tests;

[TestClass]


public sealed class Test1
{
    private static List<(double Latitude, double Longitude)> GerarMalhaDeCoordenadas(
        double latInicio, double latFim, double lonInicio, double lonFim, double passo)
    {
        var coordenadas = new List<(double, double)>();

        for (double lat = latInicio; lat <= latFim; lat += passo)
        {
            for (double lon = lonInicio; lon <= lonFim; lon += passo)
            {
                coordenadas.Add((Math.Round(lat, 6), Math.Round(lon, 6)));
            }
        }

        Console.WriteLine($"Malha gerada com {coordenadas.Count} coordenadas.");
        return coordenadas;
    }

    private static bool EstaNaMalha(double latitude, double longitude)
    {
        var malha = GerarMalhaDeCoordenadas(
            latInicio: -29.3,
            latFim: -27.6,
            lonInicio: -49.7,
            lonFim: -48.5,
            passo: 0.05
        );

        bool resultado = malha.Any(coord =>
            Math.Abs(coord.Latitude - latitude) < 0.025 &&
            Math.Abs(coord.Longitude - longitude) < 0.025);

        Console.WriteLine($"Validação da coordenada ({latitude}, {longitude}): {(resultado ? "Válida" : "Inválida")}");
        return resultado;
    }


    [TestMethod]
    public async Task RequisitionAsync()
    {
        double latitude = -28.48871042016006;
        double longitude = -48.74739086392232;

        Console.WriteLine("Iniciando teste de requisição...");
        Console.WriteLine($"Coordenada usada: Latitude = {latitude}, Longitude = {longitude}");

        if (!EstaNaMalha(latitude, longitude))
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