using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.Services;
using SurfRater.Avalonia.ViewModels.Base;

namespace SurfRater.Avalonia.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [RelayCommand]
    public void ShowTestNotification()
    {
        NotificationHelper.Show("Hello!", "This is the notification from the button.");
    }
}