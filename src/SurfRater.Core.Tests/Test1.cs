using SurfRater.Core.Data;
using SurfRater.Core.Data.Implementation.OpenMeteo;
using System.Text.Json;

namespace SurfRater.Core.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    [DataRow(1, 2, 3)]
    [DataRow(50, 10, 60)]
    [DataRow(10, 10, 20)]
    public void TestarMetodoLegal(int num1, int num2, int resultadoExperado)
    {
        var instancia = new MinhaClasseLegal();
        var result = instancia.ObterSoma(num1, num2);

        Assert.AreEqual(resultadoExperado, result);
    }
    
    [TestMethod]
    public async Task RequisitionAsync()
    {
        var url = "https://marine-api.open-meteo.com/v1/marine?latitude=-28.48262&longitude=-48.781502&hourly=wave_height,wave_direction,wave_period&current=wave_height,wave_direction,wind_wave_direction&timezone=America%2FSao_Paulo";

        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(url);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var weatherData = JsonSerializer.Deserialize<MarineWeatherResponse>(response, options);

        Assert.IsTrue(true);
    }
}
