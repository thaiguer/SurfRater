namespace SurfRater.Core.Data.ValueObjects;

/// <summary>
/// Represents a numeric value with an associated weight for weighted calculations.
/// </summary>
public class WeigthedObject<T> where T : struct, IComparable, IConvertible
{
    /// <summary>
    /// The actual value (e.g., temperature, wave height).
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// The weight associated with the value, used for weighted averages.
    /// </summary>
    public double Weight { get; }

    public WeigthedObject(T value, double weight)
    {
        Value = value;
        Weight = weight;
    }

    /// <summary>
    /// Converts the value to double and multiplies by its weight.
    /// </summary>
    public double WeightedValue => Convert.ToDouble(Value) * Weight;
}