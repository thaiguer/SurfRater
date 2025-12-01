using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.ViewModels.Base;
using SurfRater.Core.Model.Entities;

namespace SurfRater.Avalonia.ViewModels.Components;

public partial class MyBeachItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private Beach _beach;

    public MyBeachItemViewModel(Beach beach)
    {
        Beach = beach;
    }

    [RelayCommand]
    public void OpenBeachStatus()
    {
        var beachStatusViewModel = new BeachStatusViewModel(Beach);
        App.NavigationService.NavigateTo(beachStatusViewModel);
    }
}