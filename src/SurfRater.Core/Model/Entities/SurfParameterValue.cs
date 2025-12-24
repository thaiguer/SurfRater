namespace SurfRater.Core.Model.Entities;

public class SurfParameterValue(
    double currentValue,
    double idealValue)
{
    public double CurrentValue { get; } = currentValue;
    public double IdealValue { get; } = idealValue;
    public double Ratio
    {
        get
        {
            return Math.Min(CurrentValue, IdealValue) / Math.Max(CurrentValue, IdealValue);
        }
    }
}