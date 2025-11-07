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
}