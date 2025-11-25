using SurfRater.Core.Enumerators;
using SurfRater.Core.Model.ValueObjects;

namespace SurfRater.Avalonia.Model;

public class Beach : ValueObject
{
    public string Name { get; set; } = string.Empty;
    public Coordinate Coordinate { get; set; }
    public SurfCondition SurfCondition { get; set; }
    public SurfConditionColor SurfConditionColor { get; private set; } = new();
}