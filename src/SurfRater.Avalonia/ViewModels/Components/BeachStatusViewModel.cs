using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.ViewModels.Base;
using SurfRater.Core.Model.Entities;
using System.Threading.Tasks;

namespace SurfRater.Avalonia.ViewModels.Components;

public partial class BeachStatusViewModel : ViewModelBase
{
    [ObservableProperty]
    private Beach _beach;

    public BeachStatusViewModel(Beach beach)
    {
        Beach = beach;
    }

    [RelayCommand]
    private async Task UpdateStatus()
    {
        await Beach.UpdateSurfCondition();
    }
}