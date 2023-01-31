using EMonolithLib.Models.Geo.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Maths.Interfaces
{
    public interface IAzimuthCalculator
    {
        int CalculateAzimuth(GeodesicCoordinates referencePoint, GeodesicCoordinates targetPoint);

        int CalculateAzimuth(GeodesicCoordinates2D referencePoint, GeodesicCoordinates2D targetPoint);

        int CalculateAzimuth(GeodesicCoordinates referencePoint, GeodesicCoordinates2D targetPoint);

        int CalculateAzimuth(GeodesicCoordinates2D referencePoint, GeodesicCoordinates targetPoint);
    }
}
