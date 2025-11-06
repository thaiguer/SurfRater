using SurfRater.Core.MathModel.New_Model_Implementation.Models;

namespace SurfRater.Core.MathModel.New_Model_Implementation.Services
{
    public interface ISurfEvaluatorService
    {
        SurfEvaluationResult Evaluate(WeatherData weatherData, SurfStyle style, BeachProfile beach);
    }
}