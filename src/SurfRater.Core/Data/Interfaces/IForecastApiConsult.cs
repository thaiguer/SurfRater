using SurfRater.Core.Data.ValueObjects;

namespace SurfRater.Core.Data.Interfaces;

interface IForecastApiConsult
{
    Coordinate Coordinate { get; set; }
}