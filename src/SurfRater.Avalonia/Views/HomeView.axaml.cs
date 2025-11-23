using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using SurfRater.Avalonia.Services;

namespace SurfRater.Avalonia.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var window = this.GetVisualRoot() as Window;
        NotificationHelper.Show(window, "Hello!", "This is the notification from the button.");
    }
}