using EMonolithLib.Maths.Interfaces;
using EMonolithLib.Models.Geo.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Maths.Source
{
    public class AzimuthCalculator : IAzimuthCalculator
    {
        public int CalculateAzimuth(GeodesicCoordinates referencePoint, GeodesicCoordinates targetPoint)
        {
            return CalculateAzimuthSimple(
                referencePoint.Latitude, 
                referencePoint.Longitude, 
                targetPoint.Latitude, 
                targetPoint.Longitude
            );
        }

        public int CalculateAzimuth(GeodesicCoordinates2D referencePoint, GeodesicCoordinates2D targetPoint)
        {
            return CalculateAzimuthSimple(
                referencePoint.Latitude,
                referencePoint.Longitude,
                targetPoint.Latitude,
                targetPoint.Longitude
            );
        }

        public int CalculateAzimuth(GeodesicCoordinates referencePoint, GeodesicCoordinates2D targetPoint)
        {
            return CalculateAzimuthSimple(
                referencePoint.Latitude,
                referencePoint.Longitude,
                targetPoint.Latitude,
                targetPoint.Longitude
            );
        }

        public int CalculateAzimuth(GeodesicCoordinates2D referencePoint, GeodesicCoordinates targetPoint)
        {
            return CalculateAzimuthSimple(
                referencePoint.Latitude,
                referencePoint.Longitude,
                targetPoint.Latitude,
                targetPoint.Longitude
            );
        }

        private int CalculateAzimuthSimple(
            double referencePointLatitude,
            double referencePointLongitude, 
            double targetPointLatitude,
            double targetPointLongitude)
        {
            // .......................................................................
            CartesianCoordinates p1 = ToCartesianCoordinateSystem(referencePointLatitude, referencePointLongitude);
            double x1 = p1.X;
            double y1 = p1.Y;

            CartesianCoordinates p2 = ToCartesianCoordinateSystem(targetPointLatitude, targetPointLongitude);
            double x2 = p2.X;
            double y2 = p2.Y;

            double dX = x2 - x1;
            double dY = y2 - y1;
            // .......................................................................

            double Beta = 0;
            double Beta_tmp = 0;
            // ------------------------------------------------------------------------
            if (dY != 0)
                Beta_tmp = Math.Atan(Math.Abs(dX) / Math.Abs(dY));
            // -------------------------------------------------------------------------
            if ((dX == 0) && (dY >= 0))
                Beta = 0;
            // -------------------------------------------------------------------------
            else if ((dX == 0) && (dY < 0))
                Beta = Math.PI;
            // ------------------------------------------------------------------------
            else if ((dY == 0) && (dX > 0))
                Beta = Math.PI / 2;
            // -------------------------------------------------------------------------
            else if ((dY == 0) && (dX < 0))
                Beta = 3 * Math.PI / 2;
            // -------------------------------------------------------------------------
            else if ((dY > 0) && (dX > 0))
                Beta = Beta_tmp;
            // -------------------------------------------------------------------------
            else if ((dY > 0) && (dX < 0))
                Beta = 2 * Math.PI - Beta_tmp;
            // -------------------------------------------------------------------------
            else if ((dY < 0) && (dX > 0))
                Beta = Math.PI - Beta_tmp;
            // -------------------------------------------------------------------------
            else if ((dY < 0) && (dX < 0))
                Beta = Math.PI + Beta_tmp;
            // -------------------------------------------------------------------------
            // Перевод в градусы

            Beta = (Beta * 180) / Math.PI;
            //-------------------------------------------------------------------------

            return (int)Beta;
        }

        private CartesianCoordinates ToCartesianCoordinateSystem(double latitude, double longitude)
        {
            double num = Math.PI / 180.0 * longitude;
            double a = Math.PI / 180.0 * latitude;

            return new CartesianCoordinates()
            {
                X = 6378137.0 * num,
                Y = 6378137.0 *
                Math.Log(
                    Math.Tan(Math.PI / 4.0 + a * 0.5) /
                    Math.Pow(Math.Tan(Math.PI / 4.0 + Math.Asin(0.0818191908426 * Math.Sin(a)) / 2.0), 0.0818191908426)
                )
            };
        }
    }
}
