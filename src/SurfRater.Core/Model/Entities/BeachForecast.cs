using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Core.Model.ValueObjects;
using System.Text;
using System.Text.Json;

namespace SurfRater.Core.Model.Entities;

public partial class BeachForecast : ObservableObject
{
    [ObservableProperty]
    public Coordinate _coordinate;

    [ObservableProperty]
    public List<OneHourForecast> _wholeDayForecast = new List<OneHourForecast>();

    [ObservableProperty]
    public OneHourForecast _nextHourForecast;
    
    public BeachForecast(Coordinate coordinate)
    {
        Coordinate = coordinate;
        NextHourForecast = GetNextHourForecast();
    }

    public OneHourForecast GetNextHourForecast()
    {
        var now = DateTime.Now;

        string time = DateTime.MinValue.ToString();
        double temperature2m = -300;
        double windSpeed10m = -1;
        double windDirection10m = -1;
        double rain = -1;
        double windGusts10m = -1;
        double waveHeight = -1;
        double waveDirection = -1;
        double wavePeriod = -1;
        double cloudCover = -1;

        var emptyForecast = new OneHourForecast(time,
            temperature2m,
            windSpeed10m,
            windDirection10m,
            rain,
            windGusts10m,
            waveHeight,
            waveDirection,
            wavePeriod,
            cloudCover);

        try
        {
            var nextHourForecast = WholeDayForecast.FirstOrDefault();
            return nextHourForecast ?? emptyForecast;
        }
        catch
        {
            return emptyForecast;
        }
    }

    public async Task GetWholedayForecast()
    {
        var getOpenMeteoForecastResponse = await GetOpenMeteoForecastResponse();
        var weatherData = JsonSerializer.Deserialize<ValueObjects.OpenMeteoForecast.WeatherData>(getOpenMeteoForecastResponse);

        var getOpenMeteoMarineResponse = await GetOpenMeteoMarineResponse();
        var marineData = JsonSerializer.Deserialize<ValueObjects.OpenMeteoMarine.MarineData>(getOpenMeteoMarineResponse);

        if (weatherData == null) return;
        if (marineData == null) return;

        WholeDayForecast.Clear();

        for (int i = 0; i < 12; i++)
        {
            string time = weatherData.Hourly.Time[i];
            double temperature2m = weatherData.Hourly.Temperature2m[i];
            double windSpeed10m = weatherData.Hourly.WindSpeed10m[i];
            double windDirection10m = weatherData.Hourly.WindDirection10m[i];
            double rain = weatherData.Hourly.Rain[i];
            double windGusts10m = weatherData.Hourly.WindGusts10m[i];
            double waveHeight = marineData.Hourly.WaveHeight[i];
            double waveDirection = marineData.Hourly.WaveDirection[i];
            double wavePeriod = marineData.Hourly.WavePeriod[i];
            double cloudCover = -1;// weatherData.Hourly.CloudCover[i];

            var oneHourForecast = new OneHourForecast(time,
                temperature2m,
                windSpeed10m,
                windDirection10m,
                rain,
                windGusts10m,
                waveHeight,
                waveDirection,
                wavePeriod,
                cloudCover);

            WholeDayForecast.Add(oneHourForecast);
        }

        NextHourForecast = GetNextHourForecast();
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