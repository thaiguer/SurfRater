using SurfRater.Core.Model.ValueObjects;

namespace SurfRater.Core.CoordinateFilters;

public static class CoordinatesFilterService
{
    public static List<Coordinate> GerarMalhaDeCoordenadas(
        double latInicio,
        double latFim,
        double lonInicio,
        double lonFim,
        double passo)
    {
        var coordenadas = new List<Coordinate>();

        for (double lat = latInicio; lat <= latFim; lat += passo)
        {
            for (double lon = lonInicio; lon <= lonFim; lon += passo)
            {
                coordenadas.Add(new Coordinate(Math.Round(lat, 6), Math.Round(lon, 6)));
            }
        }
        return coordenadas;
    }

    public static bool EstaNaMalha(double latitude, double longitude)
    {
        var malha = GerarMalhaDeCoordenadas(
            latInicio: -29.3,
            latFim: -27.6,
            lonInicio: -49.7,
            lonFim: -48.5,
            passo: 0.05
        );

        bool resultado = malha.Any(coord =>
            Math.Abs(coord.Latitude - latitude) < 0.025 &&
            Math.Abs(coord.Longitude - longitude) < 0.025);

        return resultado;
    }
}