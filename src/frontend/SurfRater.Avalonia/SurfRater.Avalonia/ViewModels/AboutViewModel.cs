using CommunityToolkit.Mvvm.ComponentModel;
using SurfRater.Avalonia.ViewModels.Base;

namespace SurfRater.Avalonia.ViewModels;

public partial class AboutViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "This is About page!";
}