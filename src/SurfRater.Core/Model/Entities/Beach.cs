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
        Random _random = new Random();

        try
        {
            var values = Enum.GetValues(typeof(SurfCondition));
            if (values != null && values.Length > 0)
            {
                var condition = values.GetValue(_random.Next(values.Length));
                SurfCondition = condition != null ? (SurfCondition)condition : SurfCondition.Average;
            }
            else
            {
                SurfCondition = SurfCondition.Average;
            }
        }
        catch
        {
            SurfCondition = SurfCondition.Average;
        }

        await Task.CompletedTask;
    }
}