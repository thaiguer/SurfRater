using Serilog;
using SurfRater.Core.Data.ValueObjects;
using SurfRater.Core.Services;
using SurfRater.WebApi.Common;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.Services.AddScoped<WeatherService>(sp => new WeatherService(Log.Logger));

    var app = builder.Build();

    app.MapGet("/", () => "bacon!");
    app.MapGet("/health", () => Health.GetHealthMessageApi());

    app.MapGet("/wind", async (Coordinate coordinate, WeatherService weatherService) =>
    {
        var weatherData = await weatherService.GetWeatherDataAsync(coordinate);

        if (weatherData != null)
        {
            return Results.Ok(weatherData);
        }

        return Results.NotFound("Could not retrieve weather data.");
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


