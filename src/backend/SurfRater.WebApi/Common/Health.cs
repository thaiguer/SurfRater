using System.Diagnostics;

namespace SurfRater.WebApi.Common;

public static class Health
{
    public static string GetHealthMessageApi()
    {
        return $"It's alive. The API is running since {GetRunningSince().ToString()} (UTC). It has been running for {GetRunningTimeToShow()}.";
    }

    private static string GetRunningTimeToShow()
    {
        var runningTime = DateTime.UtcNow - GetRunningSince();

        if (runningTime.TotalMinutes < 1) return $"{runningTime.Seconds} seconds";
        if (runningTime.TotalHours < 1) return $"{runningTime.Minutes} minutes";
        if (runningTime.TotalDays < 1) return $"{(int)runningTime.TotalHours} hours and {runningTime.Minutes} minutes";

        return $"{(int)runningTime.TotalDays} days, {runningTime.Hours} hours and {runningTime.Minutes} minutes";
    }

    private static DateTime GetRunningSince()
    {
        return Process.GetCurrentProcess().StartTime.ToUniversalTime();
    }
}
