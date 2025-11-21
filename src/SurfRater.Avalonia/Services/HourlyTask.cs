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

public class HourlyTask2 : IHourlyTask
{
    public void RunOnce()
    {
        try
        {
            NotificationHelper.Show(null, "Hourly Task receiver 2", "Background Job receiver 2" + DateTime.Now.ToString());
        }
        catch
        {

        }
    }
}