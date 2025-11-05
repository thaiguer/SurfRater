using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace SurfRater.Maui.Notifications;

internal class SampleNotifier
{
    internal async Task ShowNoticationAsync()
    {
        await Toast.Make("Hello from .NET MAUI!", ToastDuration.Short).Show();
    }
}