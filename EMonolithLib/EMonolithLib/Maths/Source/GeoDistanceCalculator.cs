using EMonolithLib.Maths.Interfaces;
using EMonolithLib.Models.Geo.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Maths.Source
{

    public class GeoDistanceCalculator : IDistanceCalculator
    {
        public double Calculate(GeodesicCoordinates2D point1, GeodesicCoordinates point2)
        {
            return Calculate(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude);
        }

        public double Calculate(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            if (
                (latitude1 == latitude2) &&
                (longitude1 == longitude2)
            )
                return 0;
            else
                return
                    RadiansToDegrees(
                        Math.Acos(
                            Math.Sin(DegreesToRadians(latitude1)) *
                            Math.Sin(DegreesToRadians(latitude2)) +
                            Math.Cos(DegreesToRadians(latitude1)) *
                            Math.Cos(DegreesToRadians(latitude2)) *
                            Math.Cos(DegreesToRadians(longitude1 - longitude2))
                        )
                    ) * 60 * 1.1515 * 1.609344;// * 1000;
        }

        public double Calculate(GeodesicCoordinates2D point1, GeodesicCoordinates2D point2)
        {
            return Calculate(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude);
        }

        public double Calculate(GeodesicCoordinates point1, GeodesicCoordinates point2)
        {
            return Calculate(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude);
        }

        public double Calculate(GeodesicCoordinates point1, GeodesicCoordinates2D point2)
        {
            return Calculate(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude);
        }

        public double DegreesToRadians(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        public double RadiansToDegrees(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
