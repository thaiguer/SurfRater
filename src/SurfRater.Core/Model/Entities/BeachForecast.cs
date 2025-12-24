using SurfRater.Core.Enumerators;
using SurfRater.Core.Model.ValueObjects;
using System.Text;
using System.Text.Json;

namespace SurfRater.Core.Model.Entities;

public class BeachForecast
{
    public Coordinate Coordinate { get; }
    public Forecast Forecast { get; private set; }

    public BeachForecast(Coordinate coordinate)
    {
        Coordinate = coordinate;
        Forecast = GetForecast();
    }

    public SurfCondition GetNextHourSurfCondition()
    {
        //if (weatherData.WeatherData.WaveHeight.FirstOrDefault() > 1.5)
        //{
        //    SurfCondition = SurfCondition.Perfect;
        //    return;
        //}

        //if (weatherData.WeatherData.WaveHeight.FirstOrDefault() > 1)
        //{
        //    SurfCondition = SurfCondition.Decent;
        //    return;
        //}

        //if (weatherData.WeatherData.WaveHeight.FirstOrDefault() > 0.5)
        //{
        //    SurfCondition = SurfCondition.Fair;
        //    return;
        //}

        return SurfCondition.Unknown;
    }

    private Forecast GetForecast()
    {
        return new Forecast();
    }

    public async Task<string> GetOpenMeteoForecastResponse()
    {
        //https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m,wind_speed_10m,wind_direction_10m,rain,wind_gusts_10m&forecast_days=1

        var urlComposer = new StringBuilder();
        urlComposer.Append($"https://api.open-meteo.com/v1/forecast?");
        urlComposer.Append($"latitude={Coordinate.Latitude}");
        urlComposer.Append($"&longitude={Coordinate.Longitude}");
        urlComposer.Append($"&hourly=temperature_2m,wind_speed_10m,wind_direction_10m,rain,wind_gusts_10m&forecast_days=1");

        using var httpClient = new HttpClient();
        string response = await httpClient.GetStringAsync(urlComposer.ToString()) ?? string.Empty;
        return response;
        var weatherData = JsonSerializer.Deserialize<ValueObjects.OpenMeteoForecast.WeatherData>(response);
    }

    public async Task<string> GetOpenMeteoMarineResponse()
    {
        //https://marine-api.open-meteo.com/v1/marine?latitude=-28.485915980974802&longitude=-48.75046559962038&hourly=wave_height,wave_direction,wave_period&forecast_days=1

        var urlComposer = new StringBuilder();
        urlComposer.Append($"https://marine-api.open-meteo.com/v1/marine?");
        urlComposer.Append($"latitude={Coordinate.Latitude}");
        urlComposer.Append($"&longitude={Coordinate.Longitude}");
        urlComposer.Append($"&hourly=wave_height,wave_direction,wave_period&forecast_days=1");

        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(urlComposer.ToString());

        return response;
        var weatherData = JsonSerializer.Deserialize<ValueObjects.OpenMeteoMarine.MarineData>(response);
    }
}