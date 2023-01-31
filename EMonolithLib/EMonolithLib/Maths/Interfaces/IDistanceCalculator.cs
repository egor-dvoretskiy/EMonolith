using EMonolithLib.Models.Geo.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Maths.Interfaces
{
    public interface IDistanceCalculator
    {
        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="latitude1"></param>
        /// <param name="longitude1"></param>
        /// <param name="latitude2"></param>
        /// <param name="longitude2"></param>
        /// <returns>Distance in km.</returns>
        double Calculate(double latitude1, double longitude1, double latitude2, double longitude2);

        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distance in km.</returns>
        double Calculate(GeodesicCoordinates2D point1, GeodesicCoordinates2D point2);

        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distance in km.</returns>
        double Calculate(GeodesicCoordinates point1, GeodesicCoordinates point2);

        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distance in km.</returns>
        double Calculate(GeodesicCoordinates2D point1, GeodesicCoordinates point2);

        /// <summary>
        /// Calculates distance.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distance in km.</returns>
        double Calculate(GeodesicCoordinates point1, GeodesicCoordinates2D point2);

        /// <summary>
        /// This function converts decimal degrees to radians
        /// </summary>
        /// <param name="deg">Value in degrees.</param>
        /// <returns></returns>
        double DegreesToRadians(double deg);

        /// <summary>
        /// This function converts radians to decimal degrees
        /// </summary>
        /// <param name="rad">Value in radians.</param>
        /// <returns></returns>
        double RadiansToDegrees(double rad);
    }
}
