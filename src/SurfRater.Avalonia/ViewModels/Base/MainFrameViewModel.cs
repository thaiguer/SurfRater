using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SurfRater.Avalonia.ViewModels.Base;

public partial class MainFrameViewModel : ViewModelBase
{
    [ObservableProperty]
    private object _currentViewModel = new HomeViewModel();

    private HomeViewModel _homeViewModel = new HomeViewModel();
    private MyBeachesViewModel _myBeachesViewModel = new MyBeachesViewModel();
    private SettingsViewModel _settingsViewModel = new SettingsViewModel();
    private AboutViewModel _aboutViewModel = new AboutViewModel();

    [RelayCommand]
    private void ChangeViewToHome()
    {
        CurrentViewModel = _homeViewModel;
    }

    [RelayCommand]
    private void ChangeViewToMyBeaches()
    {
        CurrentViewModel = _myBeachesViewModel;
    }

    [RelayCommand]
    private void ChangeViewToSettings()
    {
        CurrentViewModel = _settingsViewModel;
    }

    [RelayCommand]
    private void ChangeViewToAbout()
    {
        CurrentViewModel = _aboutViewModel;
    }
}