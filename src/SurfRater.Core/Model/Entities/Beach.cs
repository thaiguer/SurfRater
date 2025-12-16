using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Core.Data;
using SurfRater.Core.Enumerators;
using SurfRater.Core.Model.ValueObjects;
using System.Text;
using System.Text.Json;

namespace SurfRater.Core.Model.Entities;

public partial class Beach : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private Coordinate _coordinate;

    [ObservableProperty]
    private SurfCondition _surfCondition = SurfCondition.Average;

    public string SurfConditionColor => ((SurfConditionColor)(int)SurfCondition).ToString();

    partial void OnSurfConditionChanged(SurfCondition value)
    {
        OnPropertyChanged(nameof(SurfConditionColor));
    }

    public async Task UpdateSurfCondition()
    {
        try
        {
            var urlComposer = new StringBuilder();
            urlComposer.Append($"https://marine-api.open-meteo.com/v1/marine?");
            urlComposer.Append($"latitude={Coordinate.Latitude}");
            urlComposer.Append($"&longitude={Coordinate.Longitude}");
            urlComposer.Append($"&current=wave_height,wave_direction,wind_wave_direction&timezone=auto");

            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(urlComposer.ToString());

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var weatherData = JsonSerializer.Deserialize<MarineWeatherResponse>(response, options);

            if (weatherData?.WeatherData == null)
            {
                SurfCondition = SurfCondition.Unknown;
            }
            else
            {
                if (weatherData.WeatherData.WaveHeight.FirstOrDefault() > 1.5)
                {
                    SurfCondition = SurfCondition.Perfect;
                    return;
                }

                if (weatherData.WeatherData.WaveHeight.FirstOrDefault() > 1)
                {
                    SurfCondition = SurfCondition.Decent;
                    return;
                }

                if (weatherData.WeatherData.WaveHeight.FirstOrDefault() > 0.5)
                {
                    SurfCondition = SurfCondition.Fair;
                    return;
                }

                SurfCondition = SurfCondition.Average;
            }            
        }
        catch
        {
            SurfCondition = SurfCondition.Unknown;
        }

        await Task.CompletedTask;
    }
}