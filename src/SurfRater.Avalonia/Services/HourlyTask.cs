using System;

namespace SurfRater.Avalonia.Services;

public class HourlyTask : IHourlyTask
{
    public void RunOnce()
    {
        try
        {
            NotificationHelper.Show("Hourly Task", "Background Job 1" + DateTime.Now.ToString());
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
            NotificationHelper.Show("Hourly Task receiver 2", "Background Job receiver 2" + DateTime.Now.ToString());
        }
        catch
        {

        }
    }
}