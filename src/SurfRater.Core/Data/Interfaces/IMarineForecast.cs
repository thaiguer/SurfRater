using SurfRater.Core.Data.Implementation.OpenMeteo;
using SurfRater.Core.Data.ValueObjects;

namespace SurfRater.Core.Data.Interfaces;

public interface IMarineForecast : IForecastApiConsult
{
    public Task<MarineWeatherResponse> GetForecastAsync(Coordinate coordinate);
    public DateTime Time { get; set; }
    public int Interval { get; set; }
    public double Wave_Height { get; set; }
    public double Wave_Direction { get; set; }
    public double Wind_Wave_Direction { get; set; }
}