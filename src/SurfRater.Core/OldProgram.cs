namespace SurfRater.Core;

public class OldProgram
{
    public void DoStuff()
    {
        //try
        //{
        //    // Set invariant culture to prevent issues with decimal separators in different regions
        //    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        //    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        //app.MapGet("/", () => "bacon!");
        //app.MapGet("/health", () => Health.GetHealthMessageApi());
        /*app.MapGet("/wind", async (Coordinate coordinate, WeatherService weatherService) =>
        {
            var weatherData = await weatherService.GetWeatherDataAsync(coordinate);
            if (weatherData != null)
            {
                return Results.Ok(weatherData);
            }
            return Results.NotFound("Could not retrieve weather data.");
        });*/

        /*app.MapGet("/surfspots", async (double latitude, double longitude, IHttpClientFactory httpClientFactory, string? style, int? hour, ILogger<Program> logger) =>
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "praiasBr.geojson");
            var beaches = BeachImporter.LoadFromGeoJson(filePath);
            if (beaches == null || !beaches.Any())
                return Results.NotFound("No beaches loaded.");

            var nearestBeaches = beaches
                .OrderBy(b => Math.Sqrt(Math.Pow(b.Latitude - latitude, 2) + Math.Pow(b.Longitude - longitude, 2)))
                .Take(3)
                .ToList();

            var results = new List<object>();
            var evaluator = new SurfEvaluatorService();
            var httpClient = httpClientFactory.CreateClient();

            if (!Enum.TryParse<SurfStyle>(style, true, out var surfStyle))
            {
                surfStyle = SurfStyle.Longboard;
            }

            foreach (var beach in nearestBeaches)
            {
                var beachLatitude = beach.Latitude.ToString(CultureInfo.InvariantCulture);
                var beachLongitude = beach.Longitude.ToString(CultureInfo.InvariantCulture);

                // Define URLs for both Marine and Forecast APIs
                string marineUrl = $"https://marine-api.open-meteo.com/v1/marine?latitude={beachLatitude}&longitude={beachLongitude}&hourly=wave_height,wave_direction,wave_period,wind_wave_direction&timezone=auto";
                string forecastUrl = $"https://api.open-meteo.com/v1/forecast?latitude={beachLatitude}&longitude={beachLongitude}&hourly=wind_speed_10m,wind_direction_10m&timezone=auto";

                logger.LogInformation("Requesting Marine data from: {Url}", marineUrl);
                logger.LogInformation("Requesting Forecast data from: {Url}", forecastUrl);

                // Execute both API calls in parallel
                var marineTask = httpClient.GetAsync(marineUrl);
                var forecastTask = httpClient.GetAsync(forecastUrl);

                await Task.WhenAll(marineTask, forecastTask);

                var marineResponse = await marineTask;
                var forecastResponse = await forecastTask;

                // Check if both calls were successful
                if (!marineResponse.IsSuccessStatusCode || !forecastResponse.IsSuccessStatusCode)
                {
                    if (!marineResponse.IsSuccessStatusCode)
                    {
                        var errorContent = await marineResponse.Content.ReadAsStringAsync();
                        logger.LogWarning("Failed to get MARINE data for {BeachName}. Status: {StatusCode}. Content: {ErrorContent}", beach.Name, marineResponse.StatusCode, errorContent);
                    }
                    if (!forecastResponse.IsSuccessStatusCode)
                    {
                        var errorContent = await forecastResponse.Content.ReadAsStringAsync();
                        logger.LogWarning("Failed to get FORECAST data for {BeachName}. Status: {StatusCode}. Content: {ErrorContent}", beach.Name, forecastResponse.StatusCode, errorContent);
                    }
                    continue;
                }

                // Deserialize both responses
                var marineJson = await marineResponse.Content.ReadAsStringAsync();
                var forecastJson = await forecastResponse.Content.ReadAsStringAsync();

                logger.LogInformation("Received Marine JSON for {BeachName}: {Json}", beach.Name, marineJson);
                logger.LogInformation("Received Forecast JSON for {BeachName}: {Json}", beach.Name, forecastJson);

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var marineData = JsonSerializer.Deserialize<OpenMeteoMarineResponse>(marineJson, options);
                var windDataForecast = JsonSerializer.Deserialize<OpenMeteoForecastResponse>(forecastJson, options);

                if (marineData?.Hourly?.Time == null || !marineData.Hourly.Time.Any() || windDataForecast?.Hourly?.Time == null)
                {
                    logger.LogWarning("Failed to deserialize or forecast is empty for {BeachName}.", beach.Name);
                    continue;
                }

                int timeIndex = 0;
                if (hour.HasValue)
                {
                    timeIndex = marineData.Hourly.Time.FindIndex(timeStr => DateTime.Parse(timeStr).Hour == hour.Value);
                    if (timeIndex == -1) timeIndex = 0;
                }

                // Combine data from both API calls
                var weatherData = new WeatherData
                {
                    Current = new MarineConditions
                    {
                        Wave_Height = marineData.Hourly.Wave_Height.ElementAtOrDefault(timeIndex),
                        Wave_Period = marineData.Hourly.Wave_Period.ElementAtOrDefault(timeIndex),
                        Wave_Direction = marineData.Hourly.Wave_Direction.ElementAtOrDefault(timeIndex),
                        Wind_Wave_Direction = marineData.Hourly.Wind_Wave_Direction.ElementAtOrDefault(timeIndex),
                        Wind_Speed_10m = windDataForecast.Hourly.Wind_Speed_10m?.ElementAtOrDefault(timeIndex),
                        Wind_Direction_10m = windDataForecast.Hourly.Wind_Direction_10m?.ElementAtOrDefault(timeIndex)
                    }
                };

                var result = evaluator.Evaluate(weatherData, surfStyle, beach);
                results.Add(new { BeachName = beach.Name, Evaluation = result });
            }
            return Results.Ok(results);
        });
        app.Run();
    }
    catch (Exception ex)
    {
    }
    finally
    {
   }*/
    }
}