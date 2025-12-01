using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Avalonia.ViewModels.Base;
using SurfRater.Core.Model.Entities;

namespace SurfRater.Avalonia.ViewModels.Components;

public partial class BeachStatusViewModel : ViewModelBase
{
    [ObservableProperty]
    private Beach _beach;

    public BeachStatusViewModel(Beach beach)
    {
        Beach = beach;
    }
}