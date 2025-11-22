using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SurfRater.Avalonia.ViewModels.Base;

public partial class MainFrameViewModel : ViewModelBase
{
    [ObservableProperty]
    private object _currentViewModel = new HomeViewModel();

    [RelayCommand]
    private void ChangeViewToHome()
    {
        CurrentViewModel = new HomeViewModel();
    }

    [RelayCommand]
    private void ChangeViewToMyBeaches()
    {
        CurrentViewModel = new MyBeachesViewModel();
    }

    [RelayCommand]
    private void ChangeViewToSettings()
    {
        CurrentViewModel = new SettingsViewModel();
    }

    [RelayCommand]
    private void ChangeViewToAbout()
    {
        CurrentViewModel = new AboutViewModel();
    }
}