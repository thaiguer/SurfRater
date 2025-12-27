using SurfRater.Core.Enumerators;
using SurfRater.Core.Model.ValueObjects;

namespace SurfRater.Core.Model;

public class ConditionCalculator
{
    public SurfCondition GetSurfCondition(OneHourForecast oneHourForecast)
    {
        if (oneHourForecast.WindSpeed10m.CurrentValue > 1)
        {
            return SurfCondition.Splendid;
        }

        return SurfCondition.Terrible;
    }
}