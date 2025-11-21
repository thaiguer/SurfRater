using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using SurfRater.Avalonia.Services;
using Splat;

namespace SurfRater.Avalonia.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private WindowNotificationManager? _notificationManager;

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var window = this.GetVisualRoot() as Window;
        NotificationHelper.Show(window, "Hello!", "This is the notification from the button.");
        
        //if (_notificationManager == null)
        //{
        //    var window = this.GetVisualRoot() as Window;
        //    if (window != null)
        //    {
        //        _notificationManager = new WindowNotificationManager(window)
        //        {
        //            Position = NotificationPosition.TopRight
        //        };
        //    }
        //}

        //_notificationManager?.Show(new Notification("Hello!", "This is a notification.", NotificationType.Information));

        //var notifier = Locator.Current.GetService<INotificationService>();
        //notifier?.ShowNotification("Olá Thaiguer!", "Sua notificação Android está funcionando!");
    }
}