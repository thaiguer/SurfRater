using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace SurfRater.Core.Data.ValueObjects;

public class Coordinate : ValueObject
{
    public double Latitude { get; }
    public double Longitude { get; }

    public Coordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public override string ToString()
    {
        return $"Lat: {Latitude}, Lon: {Longitude}";
    }

    public static ValueTask<Coordinate?> BindAsync(HttpContext context)
    {
        var latitudeString = context.Request.Query["latitude"].ToString();
        if (latitudeString.EndsWith("."))
        {
            latitudeString = latitudeString.TrimEnd('.');
        }

        if (!double.TryParse(latitudeString, CultureInfo.InvariantCulture, out var latitude))
            return ValueTask.FromResult<Coordinate?>(null);

        var longitudeString = context.Request.Query["longitude"].ToString();
        if (longitudeString.EndsWith("."))
        {
            longitudeString = longitudeString.TrimEnd('.');
        }

        if (!double.TryParse(longitudeString, CultureInfo.InvariantCulture, out var longitude))
            return ValueTask.FromResult<Coordinate?>(null);

        return ValueTask.FromResult<Coordinate?>(new Coordinate(latitude, longitude));
    }
}