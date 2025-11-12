using CommunityToolkit.Mvvm.ComponentModel;

namespace SurfRater.Avalonia.ViewModels;

public partial class AboutViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "This is About page!";
}