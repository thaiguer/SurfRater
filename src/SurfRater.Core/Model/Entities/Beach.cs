using SurfRater.Core.Enumerators;
using SurfRater.Core.Model.ValueObjects;

namespace SurfRater.Core.Model.Entities;

public class Beach : ValueObject
{
    public string Name { get; set; } = string.Empty;
    public Coordinate Coordinate { get; set; }
    public SurfCondition SurfCondition { get; set; } = new SurfCondition();
    //public SurfConditionColor SurfConditionColor { get; private set; } = new();

    public async Task UpdateSurfCondition()
    {
        SurfCondition = new SurfCondition();
        SurfCondition = SurfCondition.Outstanding;
    }
}