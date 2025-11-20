using System;

namespace SurfRater.Avalonia.Services;

public class HourlyTask : IHourlyTask
{
    public void RunOnce()
    {
        try
        {
            NotificationHelper.Show(null, "Hourly Task", "Background Job " + DateTime.Now.ToString());
        }
        catch
        {

        }
    }
}