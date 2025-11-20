using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using AndroidX.Work;
using Avalonia;
using Avalonia.Android;
using Java.Util.Concurrent;
using Splat;
using SurfRater.Avalonia.Android.Services;
using SurfRater.Avalonia.Android.Workers;
using SurfRater.Avalonia.Services;

namespace SurfRater.Avalonia.Android;

[Activity(
    Label = "SurfRater.Avalonia.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    const int NotificationPermissionRequestCode = 1001;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.PostNotifications) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.PostNotifications }, NotificationPermissionRequestCode);
            }
        }

        var request = PeriodicWorkRequest.Builder
            .From<HourlyWorker>(1, TimeUnit.Minutes)
            .Build();
        
        WorkManager.GetInstance(this).EnqueueUniquePeriodicWork(
            "HourlyWork",
            ExistingPeriodicWorkPolicy.Update,
            request
        );

        //
        //var request = OneTimeWorkRequest.Builder
        //            .From<HourlyWorker>()
        //            .Build();

        //WorkManager.GetInstance(this).Enqueue(request);
        //

        /////////
        var alarmManager = (AlarmManager)GetSystemService(AlarmService);
        var intent = new Intent(this, typeof(HourlyReceiver));
        var pending = PendingIntent.GetBroadcast(
            this, 0, intent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);

        long intervalMillis = 60 * 1000; // 1 hour
        long triggerAtMillis = Java.Lang.JavaSystem.CurrentTimeMillis() + intervalMillis;

        // Inexact repeating (better for battery)
        alarmManager.SetInexactRepeating(
            AlarmType.RtcWakeup,
            triggerAtMillis,
            intervalMillis,
            pending
        );

        ////////////
    }

    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
        .WithInterFont()
        .AfterSetup(_ =>
        {
            Locator.CurrentMutable.RegisterConstant(new AndroidNotificationService(), typeof(INotificationService));
        });
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        if (requestCode == NotificationPermissionRequestCode)
        {
            if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
            {
                // Permission granted — you can show notifications
            }
            else
            {
                // Permission denied — maybe show a message or fallback
            }
        }
    }
}