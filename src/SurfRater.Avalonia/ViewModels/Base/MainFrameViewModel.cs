using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.Navigation;

namespace SurfRater.Avalonia.ViewModels.Base;

public partial class MainFrameViewModel : ViewModelBase
{
    public NavigationService Navigation => App.NavigationService;

    public MainFrameViewModel()
    {
        App.NavigationService.NavigateTo(new HomeViewModel());
    }

    [RelayCommand]
    private void ChangeViewToHome()
    {
        App.NavigationService.NavigateToHome();
    }

    [RelayCommand]
    private void ChangeViewToMyBeaches()
    {
        App.NavigationService.NavigateToMyBeaches();
    }

    [RelayCommand]
    private void ChangeViewToSettings()
    {
        App.NavigationService.NavigateToSettings();
    }

    [RelayCommand]
    private void ChangeViewToAbout()
    {
        App.NavigationService.NavigateToAbout();
    }
}