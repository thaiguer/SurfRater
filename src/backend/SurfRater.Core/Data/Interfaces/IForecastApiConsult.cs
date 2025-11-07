using SurfRater.Core.Data.ValueObjects;

namespace SurfRater.Core.Data.Interfaces;

public interface IForecastApiConsult
{
    Coordinate Coordinate { get; set; }
}