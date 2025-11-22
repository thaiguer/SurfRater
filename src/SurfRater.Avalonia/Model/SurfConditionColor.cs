using Avalonia.Media;
using SurfRater.Core.Enumerators;
using System.Collections.Generic;

namespace SurfRater.Avalonia.Model;

public class SurfConditionColor
{
    private static readonly Dictionary<SurfCondition, Color> _colors = new()
    {
        { SurfCondition.Terrible, Colors.Black },
        { SurfCondition.VeryBad, Colors.DarkRed },
        { SurfCondition.Bad, Colors.Red },
        { SurfCondition.Poor, Colors.OrangeRed },
        { SurfCondition.BelowAverage, Colors.Orange },
        { SurfCondition.Average, Colors.Goldenrod },
        { SurfCondition.Fair, Colors.Yellow },
        { SurfCondition.Decent, Colors.YellowGreen },
        { SurfCondition.Good, Colors.Green },
        { SurfCondition.VeryGood, Colors.MediumSeaGreen },
        { SurfCondition.Excellent, Colors.Cyan },
        { SurfCondition.Superb, Colors.DeepSkyBlue },
        { SurfCondition.Splendid, Colors.DodgerBlue },
        { SurfCondition.Outstanding, Colors.RoyalBlue },
        { SurfCondition.Perfect, Colors.Blue }
    };

    public static Color GetColor(SurfCondition condition) => _colors[condition];
}