using SurfRater.Core.Model.ValueObjects;
using System.Text;
using System.Text.Json;

namespace SurfRater.Core.Model.Entities;

public class BeachForecast
{
    public Coordinate Coordinate { get; }
    public List<OneHourForecast> WholeDayForecast { get; private set; }

    public BeachForecast(Coordinate coordinate)
    {
        Coordinate = coordinate;
    }

    public async void GetWholedaySurfCondition()
    {
        var getOpenMeteoForecastResponse = await GetOpenMeteoForecastResponse();
        var weatherData = JsonSerializer.Deserialize<ValueObjects.OpenMeteoForecast.WeatherData>(getOpenMeteoForecastResponse);

        var getOpenMeteoMarineResponse = await GetOpenMeteoMarineResponse();
        var marineData = JsonSerializer.Deserialize<ValueObjects.OpenMeteoMarine.MarineData>(getOpenMeteoMarineResponse);

        var wholeDayForecast = new List<OneHourForecast>();

        for(int i = 0; i < 12; i++)
        {
            //string time = 
            //weatherData.Hourly.WindDirection10m

            //var oneHourForecast = new OneHourForecast();
        }
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
    }
}