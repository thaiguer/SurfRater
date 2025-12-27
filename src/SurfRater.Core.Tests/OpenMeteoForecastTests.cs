using Newtonsoft.Json.Bson;
using SurfRater.Core.Model.Entities;
using SurfRater.Core.Model.ValueObjects;

namespace SurfRater.Core.Tests;

[TestClass]
public class OpenMeteoForecastAndMarineTests
{
    readonly Coordinate _lagunaCoordinate = new(-28.485915980974802, -48.75046559962038);

    [TestMethod]
    public void SimpleRequestForecast()
    {
        var beachForecast = new BeachForecast(_lagunaCoordinate);
        var openMeteoForecastResponse = beachForecast.GetOpenMeteoForecastResponse();
        var result = openMeteoForecastResponse.Result;

        Assert.IsNotNull(openMeteoForecastResponse);
        Assert.IsFalse(string.IsNullOrEmpty(result));
        Assert.IsFalse(string.IsNullOrWhiteSpace(result));
    }

    [TestMethod]
    public void SimpleRequestMarine()
    {
        var beachForecast = new BeachForecast(_lagunaCoordinate);
        var openMeteoForecastResponse = beachForecast.GetOpenMeteoMarineResponse();
        var result = openMeteoForecastResponse.Result;

        Assert.IsNotNull(openMeteoForecastResponse);
        Assert.IsFalse(string.IsNullOrEmpty(result));
        Assert.IsFalse(string.IsNullOrWhiteSpace(result));
    }

    [TestMethod]
    public async Task WholeDayForecast()
    {
        var beachForecast = new BeachForecast(_lagunaCoordinate);
        await beachForecast.GetWholedayForecast();
        var wholeDayForecast = beachForecast.WholeDayForecast;
    }
}