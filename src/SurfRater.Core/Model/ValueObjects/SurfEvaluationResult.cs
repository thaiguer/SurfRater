using SurfRater.Core.Enumerators;

namespace SurfRater.Core.Model.ValueObjects;

public class SurfEvaluationResult
{
    public SurfStyle Style { get; set; }
    public string Rating { get; set; }
    public string Commentary { get; set; }
}