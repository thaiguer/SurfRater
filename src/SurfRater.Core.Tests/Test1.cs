using SurfRater.Core.Data.Interfaces;

namespace SurfRater.Core.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public async Task TestMethod1Async()
    {
        IMarineForecast marineForecast = new Data.Implementation.OpenMeteoMarineForecast();
        var result = await marineForecast.GetForecastAsync(-28.422904205663045, -48.737681609410465);
        Console.WriteLine(result.ToString());
    }
}
