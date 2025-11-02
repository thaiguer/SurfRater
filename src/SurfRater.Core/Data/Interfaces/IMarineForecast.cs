using SurfRater.Core.Data.Implementation.OpenMeteo;

namespace SurfRater.Core.Data.Interfaces;

public interface IMarineForecast : IForecastApiConsult
{
    public Task<MarineForecastResponse> GetForecastAsync(double latitude, double longitude);
}