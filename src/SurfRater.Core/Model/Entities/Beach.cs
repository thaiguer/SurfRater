using SurfRater.Core.Enumerators;
using SurfRater.Core.Model.ValueObjects;
using System;

namespace SurfRater.Core.Model.Entities;

public class Beach : ValueObject
{
    public string Name { get; set; } = string.Empty;
    public Coordinate Coordinate { get; set; }
    public SurfCondition SurfCondition { get; set; } = new SurfCondition();

    public async Task UpdateSurfCondition()
    {
        Random _random = new Random();
        
        try
        {
            var values = Enum.GetValues(typeof(SurfCondition));
            if (values != null && values.Length > 0)
            {
                var condition = values.GetValue(_random.Next(values.Length));
                if(condition != null)
                {
                    SurfCondition = (SurfCondition)condition;
                }
                else
                {
                    SurfCondition = SurfCondition.Average;
                }
            }
            else
            {
                SurfCondition = SurfCondition.Average;
            }
        }
        catch
        {
            SurfCondition = SurfCondition.Average;
        }

        await Task.CompletedTask;
    }

    public string SurfConditionColor
    {
        get
        {
            return ((SurfConditionColor)(int)SurfCondition).ToString();
        }
    }
}