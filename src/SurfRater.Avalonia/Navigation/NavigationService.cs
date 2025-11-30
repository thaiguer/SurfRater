using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Avalonia.ViewModels;

namespace SurfRater.Avalonia.Navigation;

public partial class NavigationService : ObservableObject
{
    private HomeViewModel _homeViewModel = new HomeViewModel();
    private MyBeachesViewModel _myBeachesViewModel = new MyBeachesViewModel();
    private SettingsViewModel _settingsViewModel = new SettingsViewModel();
    private AboutViewModel _aboutViewModel = new AboutViewModel();

    [ObservableProperty]
    public object _currentViewModel;

    public NavigationService()
    {
        CurrentViewModel = _homeViewModel;
    }

    public void NavigateTo(object viewModel)
    {
        CurrentViewModel = viewModel;
    }

    public void NavigateToHome()
    {
        NavigateTo(_homeViewModel);
    }

    public void NavigateToMyBeaches()
    {
        NavigateTo(_myBeachesViewModel);
    }

    public void NavigateToSettings()
    {
        NavigateTo(_settingsViewModel);
    }

    public void NavigateToAbout()
    {
        NavigateTo(_aboutViewModel);
    }
}