using Android.Content;
using AndroidX.Work;
using SurfRater.Avalonia.Services;

namespace SurfRater.Avalonia.Android.Workers;

public class HourlyWorker : Worker
{
    public HourlyWorker(Context context, WorkerParameters workerParams) : base(context, workerParams) { }

    public override Result DoWork()
    {
        try
        {
            // Call into shared Core logic
            var task = new HourlyTask();
            task.RunOnce();

            return Result.InvokeSuccess();
        }
        catch
        {
            return Result.InvokeFailure();
        }
    }
}