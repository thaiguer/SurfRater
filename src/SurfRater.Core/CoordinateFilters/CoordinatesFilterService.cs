using SurfRater.Core.Data.ValueObjects;

namespace SurfRater.Core.CoordinateFilters;

public class CoordinatesFilterService
{
    public List<Coordinate> GerarMalhaDeCoordenadas(
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

        Console.WriteLine($"Malha gerada com {coordenadas.Count} coordenadas.");
        return coordenadas;
    }

    public bool EstaNaMalha(double latitude, double longitude)
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

        Console.WriteLine($"Validação da coordenada ({latitude}, {longitude}): {(resultado ? "Válida" : "Inválida")}");
        return resultado;
    }
}