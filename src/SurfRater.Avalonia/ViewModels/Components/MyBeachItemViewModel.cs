using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.ViewModels.Base;
using SurfRater.Core.Model.Entities;

namespace SurfRater.Avalonia.ViewModels.Components;

public partial class MyBeachItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _color = string.Empty;

    [RelayCommand]
    public void OpenBeachStatus()
    {
        var beach = new Beach();
        beach.Name = _name;

        var beachStatusViewModel = new BeachStatusViewModel(beach);
        App.NavigationService.NavigateTo(beachStatusViewModel);
    }
}