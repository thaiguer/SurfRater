using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Avalonia.ViewModels.Base;

namespace SurfRater.Avalonia.ViewModels.Components;

public partial class MyBeachItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _color;
}