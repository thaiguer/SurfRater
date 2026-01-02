namespace SurfRater.Core.Model.ValueObjects;

public sealed class Coordinate : ValueObject
{
    public double Latitude { get; }
    public double Longitude { get; }

    public Coordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public string LatitudeToText
    {
        get
        {
            return $"Latitude: {Latitude}";
        }
    }

    public string LongitudeToText
    {
        get
        {
            return $"Longitude: {Longitude}";
        }
    }
}