using Android.Content;
using SurfRater.Avalonia.Services;
using System;

namespace SurfRater.Avalonia.Android.Workers;

[BroadcastReceiver(Enabled = true, Exported = true)]
public class HourlyReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        // Call your shared task
        var task = new HourlyTask2();
        task.RunOnce();
    }
}