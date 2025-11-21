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
    private void ChangeViewToAbout()
    {
        CurrentViewModel = new AboutViewModel();
    }
}