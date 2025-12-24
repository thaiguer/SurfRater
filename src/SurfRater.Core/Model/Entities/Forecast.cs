using SurfRater.Core.Model.ValueObjects;

namespace SurfRater.Core.Model.Entities;

public class Forecast
{
    public List<OneHourForecast> OneDayForecast { get; set; }
}