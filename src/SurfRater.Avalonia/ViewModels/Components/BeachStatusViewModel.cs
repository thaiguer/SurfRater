using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Avalonia.Model;
using SurfRater.Avalonia.ViewModels.Base;

namespace SurfRater.Avalonia.ViewModels.Components;

public partial class BeachStatusViewModel : ViewModelBase
{
    public BeachStatusViewModel(Beach beach)
    {
        Latitude = beach.Coordinate.Latitude.ToString();
        Longitude = beach.Coordinate.Longitude.ToString();
    }
    
    [ObservableProperty]
    private string _latitude = string.Empty;

    [ObservableProperty]
    private string _longitude = string.Empty;
}