using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.Services;
using SurfRater.Avalonia.ViewModels.Base;

namespace SurfRater.Avalonia.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _useDarkTheme = false;

    [ObservableProperty]
    private bool _useLightTheme = false;

    [ObservableProperty]
    private bool _useSystemTheme = true;

    [RelayCommand]
    private void SetThemeToDark()
    {
        ThemeController.SetTheme(ThemeVariant.Dark);
    }

    [RelayCommand]
    private void SetThemeToLight()
    {
        ThemeController.SetTheme(ThemeVariant.Light);
    }

    [RelayCommand]
    private void SetThemeToSystem()
    {
        ThemeController.SetTheme(ThemeVariant.Default);
    }
}