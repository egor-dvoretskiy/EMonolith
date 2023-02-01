using EMonolithLib.Models.Geo.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Maths.Interfaces
{
    public interface IGeoMetricsCalculator<T>
    {
        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="latitude1"></param>
        /// <param name="longitude1"></param>
        /// <param name="latitude2"></param>
        /// <param name="longitude2"></param>
        /// <returns>Distance in km.</returns>
        T Calculate(double latitude1, double longitude1, double latitude2, double longitude2);

        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distance in km.</returns>
        T Calculate(GeodesicCoordinates2D point1, GeodesicCoordinates2D point2);

        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distance in km.</returns>
        T Calculate(GeodesicCoordinates point1, GeodesicCoordinates point2);

        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distance in km.</returns>
        T Calculate(GeodesicCoordinates2D point1, GeodesicCoordinates point2);

        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distance in km.</returns>
        T Calculate(GeodesicCoordinates point1, GeodesicCoordinates2D point2);
    }
}
