using NetTopologySuite.Geometries;

namespace NetworkProviderDe.Domain.Services;

public static class GeographyService
{
    public static Point GeographicLocation(double latitude, double longitude)
    {
        return new Point(longitude, latitude) { SRID = 4326 };
    }
}
