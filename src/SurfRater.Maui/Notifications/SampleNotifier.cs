using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Plugin.LocalNotification;

namespace SurfRater.Maui.Notifications;

internal class SampleNotifier
{
    internal async Task ShowNoticationAsync()
    {
        await Toast.Make("Hello from 111111!", ToastDuration.Short).Show();
        await Snackbar.Make("Hello from 22222!", duration: TimeSpan.FromSeconds(3)).Show();
    }

    internal async Task ShowAsync()
    {
        var notification = new NotificationRequest
        {
            NotificationId = 100,
            Title = "System Tray Alert",
            Description = "This appears in the Android notification bar!",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(2)
            }
        };

        await LocalNotificationCenter.Current.Show(notification);
    }
}