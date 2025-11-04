using SurfRater.Core.Data.Implementation.OpenMeteo;
using SurfRater.Core.Data.Interfaces;
using SurfRater.Core.Data.ValueObjects;
using System.Text.Json;

namespace SurfRater.Core.Data.Implementation;

public class OpenMeteoMarineForecast : IMarineForecast
{
    //aqui vai receber dados da API do OpenMeteo
    //https://open-meteo.com/en/docs/marine-weather-api?hourly=swell_wave_height,swell_wave_direction,wave_height,wave_direction,wave_period,swell_wave_period,swell_wave_peak_period,wind_wave_peak_period,wind_wave_height,wind_wave_direction,wind_wave_period,secondary_swell_wave_height,secondary_swell_wave_period,secondary_swell_wave_direction,tertiary_swell_wave_direction,sea_level_height_msl,sea_surface_temperature,ocean_current_velocity,ocean_current_direction,tertiary_swell_wave_period,tertiary_swell_wave_height&latitude=-28.48633789882946&longitude=-48.75997833457601#settings

    private static readonly HttpClient httpClient = new HttpClient();

    public Coordinate Coordinate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public async Task<MarineWeatherResponse> GetForecastAsync(double latitude, double longitude)
    {
        string url = $"https://marine-api.open-meteo.com/v1/marine?latitude={latitude}&longitude={longitude}&hourly=swell_wave_height,swell_wave_direction,wave_height,wave_direction,wave_period,swell_wave_period,swell_wave_peak_period,wind_wave_direction,wind_wave_height&forecast_days=3";

        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var forecast = JsonSerializer.Deserialize<MarineWeatherResponse>(json);

        return forecast;
    }
}