using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Core.Enumerators;
using SurfRater.Core.Model.ValueObjects;

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
            var beachForecast = new BeachForecast(Coordinate);
            await beachForecast.GetWholedayForecast();
            var wholeDayForecast = beachForecast.WholeDayForecast;

            var nextHour = wholeDayForecast.FirstOrDefault();

            if(nextHour == null)
            {
                SurfCondition = SurfCondition.Unknown;
                return;
            }
            
            var conditionCalculator = new ConditionCalculator();
            SurfCondition = conditionCalculator.GetSurfCondition(nextHour);
        }
        catch
        {
            SurfCondition = SurfCondition.Unknown;
        }

        await Task.CompletedTask;
    }
}