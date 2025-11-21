using System.Text.Json;
using SurfRater.Core.Data.Implementation.OpenMeteo;
using SurfRater.Core.Data.ValueObjects;

namespace SurfRater.Core.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        //private readonly ILogger _logger;

        public WeatherService()
        {
            _httpClient = new HttpClient();
            //_logger = logger;
        }

        public async Task<MarineWeatherResponse> GetWeatherDataAsync(Coordinate coordinate)
        {
            var url = $"https://marine-api.open-meteo.com/v1/marine?latitude={coordinate.Latitude}&longitude={coordinate.Longitude}&hourly=wind_wave_direction,wave_height,wave_direction";
            var response = await _httpClient.GetAsync(url);


            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                try
                {
                    var marineWeatherResponse = JsonSerializer.Deserialize<MarineWeatherResponse>(json);
                    return marineWeatherResponse;
                }
                catch (JsonException ex)
                {
                    //_logger.Error(ex, "Error deserializing Open-Meteo API response: {JsonResponse}", json);
                    return null;
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                //_logger.Warning("Open-Meteo API call failed with status code {StatusCode} and content: {ErrorContent}", response.StatusCode, errorContent);
                return null;
            }
        }
    }
}
