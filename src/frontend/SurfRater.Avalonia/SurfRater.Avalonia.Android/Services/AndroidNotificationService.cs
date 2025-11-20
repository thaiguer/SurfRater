using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using SurfRater.Avalonia.Services;
using Android.Content.PM;
using Android;

namespace SurfRater.Avalonia.Android.Services;

public class AndroidNotificationService : INotificationService
{
    private const string ChannelId = "default_channel";

    public void ShowNotification(string title, string message)
    {
        var context = Application.Context;

        // ✅ Android 13+ requires runtime permission for notifications
        if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu &&
            ContextCompat.CheckSelfPermission(context, Manifest.Permission.PostNotifications) != Permission.Granted)
        {
            return; // Permission not granted — skip notification
        }

        var notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
        if (notificationManager == null)
            return;

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            var channel = new NotificationChannel(ChannelId, "Default Channel", NotificationImportance.High)
            {
                Description = "General notifications"
            };
            notificationManager.CreateNotificationChannel(channel);
        }

        var intent = new Intent(context, typeof(MainActivity));
        intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
        var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.Immutable);

        var builder = new NotificationCompat.Builder(context, ChannelId)
            .SetSmallIcon(Android.Resource.Drawable.Icon)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetPriority(NotificationCompat.PriorityHigh)
            .SetContentIntent(pendingIntent)
            .SetAutoCancel(true);

        NotificationManagerCompat.From(context).Notify(new System.Random().Next(), builder.Build());
    }
}