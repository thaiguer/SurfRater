using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Splat;

namespace SurfRater.Avalonia.Services;

public static class NotificationHelper
{
    public static void Show(string title, string message)
    {
        ShowOnWindow(title, message);
        ShowOnMobile(title, message);
    }

    private static WindowNotificationManager? _windowManager;
    private static void ShowOnWindow(string title, string message)
    {
        var window = App.MainWindow;

        if (window == null) return;

        if (_windowManager == null)
        {
            _windowManager = new WindowNotificationManager(window)
            {
                Position = NotificationPosition.TopRight
            };
        }

        _windowManager.Show(new Notification(title, message, NotificationType.Information));
    }

    private static void ShowOnMobile(string title, string message)
    {
        // Android system notifications (via Splat service)
        var notifier = Locator.Current.GetService<INotificationService>();
        notifier?.ShowNotification(title, message);
    }
}