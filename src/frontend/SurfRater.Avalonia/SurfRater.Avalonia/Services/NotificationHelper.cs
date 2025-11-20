using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Splat;

namespace SurfRater.Avalonia.Services;

public static class NotificationHelper
{
    private static WindowNotificationManager? _windowManager;

    /// <summary>
    /// Show a notification in Avalonia window (desktop) and via INotificationService (Android).
    /// </summary>
    public static void Show(Window? window, string title, string message)
    {
        // Avalonia desktop notifications
        if (window != null)
        {
            if (_windowManager == null)
            {
                _windowManager = new WindowNotificationManager(window)
                {
                    Position = NotificationPosition.TopRight
                };
            }

            _windowManager.Show(new Notification(title, message, NotificationType.Information));
        }

        // Android system notifications (via Splat service)
        var notifier = Locator.Current.GetService<INotificationService>();
        notifier?.ShowNotification(title, message);
    }
}