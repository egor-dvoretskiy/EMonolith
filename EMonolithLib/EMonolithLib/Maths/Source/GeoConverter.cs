using EMonolithLib.Models.Geo.Coordinates;
using System;

namespace EMonolithLib.Maths.Source
{
    public class GeoConverter
    {
        public void GeodesicToLocalTerestrial(
            GeodesicCoordinates zeroPoint,
            CartesianCoordinates zeroPointGeocentric,
            GeodesicCoordinates geodesic,
            out CartesianCoordinates localTerestrial)
        {
            GeodesicToGeocentric(geodesic, out var geocentric);
            GeocentricToLocalTerestrial(zeroPoint, zeroPointGeocentric, geocentric, out localTerestrial);
        }

        public void LocalTerestrialToGeodesic(
            GeodesicCoordinates zeroPoint,
            CartesianCoordinates zeroPointGeocentric,
            CartesianCoordinates localTerestrial,
            out GeodesicCoordinates geodesic)
        {
            LocalTerestrialToGeocentric(zeroPoint, zeroPointGeocentric, localTerestrial, out CartesianCoordinates geocentric);
            GeocentricToGeodesic(geocentric, out geodesic);
        }

        public void GeodesicToGeocentric(
            GeodesicCoordinates geodesic, 
            out CartesianCoordinates geocentric)
        {
            double N = 0;      // Радиус кривизны первого вертикала
            double e2_tmp = 0; // Квадрат эксцентриситета
            double Lat_Coord_tmp = 0;
            double Long_Coord_tmp = 0;
            double a1W = 0; // Сжатие
            double aW = 0; // Большая полуось

            // Эллипсоид WGS84 (GRS80, эти два эллипсоида сходны по большинству параметров)
            a1W = 1 / 298.257223563; // Сжатие
            aW = 6378137;  // Большая полуось
            // **************************************************** Initial conditions

            // grad->rad
            Lat_Coord_tmp = (geodesic.Latitude * Math.PI) / 180;
            Long_Coord_tmp = (geodesic.Longitude * Math.PI) / 180;

            // ...................................................................

            // N *********************************************************************
            // Квадрат эксцентриситета
            e2_tmp = 2 * a1W - Math.Pow(a1W, 2);

            // Радиус кривизны первого вертикала
            // (aW-большая полуось эллипсоида WGS84)

            if (Math.Sqrt(1 - e2_tmp * Math.Pow(Math.Sin(Lat_Coord_tmp), 2)) > 1E-15)
                N = aW / Math.Sqrt(1 - e2_tmp * Math.Pow(Math.Sin(Lat_Coord_tmp), 2));
            else
                N = aW / 1E-15;

            // ********************************************************************* N

            // XYZ *******************************************************************

            geocentric = new CartesianCoordinates()
            {
                X = (N + geodesic.Altitude) * Math.Cos(Lat_Coord_tmp) * Math.Cos(Long_Coord_tmp),
                Y = (N + geodesic.Altitude) * Math.Cos(Lat_Coord_tmp) * Math.Sin(Long_Coord_tmp),
                Z = ((1 - e2_tmp) * N + geodesic.Altitude) * Math.Sin(Lat_Coord_tmp),
            };

            // ******************************************************************* XYZ
        }

        public void GeocentricToLocalTerestrial(
            GeodesicCoordinates zeroPoint, 
            CartesianCoordinates zeroPointGeocentric, 
            CartesianCoordinates pointGeocentric, 
            out CartesianCoordinates localTerestrial)
        {
            localTerestrial = new CartesianCoordinates()
            {
                X = -(pointGeocentric.X - zeroPointGeocentric.X) * Math.Sin(zeroPoint.Latitude) * Math.Cos(zeroPoint.Longitude) -
                     (pointGeocentric.Y - zeroPointGeocentric.Y) * Math.Sin(zeroPoint.Latitude) * Math.Sin(zeroPoint.Longitude) +
                     (pointGeocentric.Z - zeroPointGeocentric.Z) * Math.Cos(zeroPoint.Latitude),
                Y = (pointGeocentric.X - zeroPointGeocentric.X) * Math.Sin(zeroPoint.Longitude) -
                     (pointGeocentric.Y - zeroPointGeocentric.Y) * Math.Cos(zeroPoint.Longitude),
                Z = (pointGeocentric.X - zeroPointGeocentric.X) * Math.Cos(zeroPoint.Latitude) * Math.Cos(zeroPoint.Longitude) +
                     (pointGeocentric.Y - zeroPointGeocentric.Y) * Math.Cos(zeroPoint.Latitude) * Math.Sin(zeroPoint.Longitude) +
                     (pointGeocentric.Z - zeroPointGeocentric.Z) * Math.Sin(zeroPoint.Latitude),
            };
        }

        public void LocalTerestrialToGeocentric(
            GeodesicCoordinates zeroPoint,
            CartesianCoordinates zeroPointGeocentric,
            CartesianCoordinates localTerestrial,
            out CartesianCoordinates pointGeocentric)
        {
            pointGeocentric = new CartesianCoordinates()
            {
                X = -localTerestrial.X * Math.Sin(zeroPoint.Latitude) * Math.Cos(zeroPoint.Longitude) +
                    localTerestrial.Y * Math.Sin(zeroPoint.Longitude) +
                    localTerestrial.Z * Math.Cos(zeroPoint.Latitude) * Math.Cos(zeroPoint.Longitude) +
                    zeroPointGeocentric.X,
                Y = -localTerestrial.X * Math.Sin(zeroPoint.Latitude) * Math.Sin(zeroPoint.Longitude) -
                    localTerestrial.Y * Math.Cos(zeroPoint.Longitude) +
                    localTerestrial.Z * Math.Cos(zeroPoint.Latitude) * Math.Sin(zeroPoint.Longitude) +
                    zeroPointGeocentric.Y,
                Z = localTerestrial.X * Math.Cos(zeroPoint.Latitude) +
                    localTerestrial.Z * Math.Sin(zeroPoint.Latitude) +
                    zeroPointGeocentric.Z,
            };
        }

        public void GeocentricToGeodesic(
            CartesianCoordinates pointGeocentric,
            out GeodesicCoordinates geodesic)
        {
            geodesic = new GeodesicCoordinates();

            double e2_tmp = 0; // Квадрат эксцентриситета

            // Вспомогательные величины
            double D_tmp = 0;
            double La_tmp = 0;
            double r_tmp = 0;
            double c_tmp = 0;
            double p_tmp = 0;
            double b_tmp = 0;
            double S1_tmp = 0;
            double S2_tmp = 0;
            double d_tmp = 0;

            double delt_d_tmp = 0;

            double X_Coord_tmp = 0;
            double Y_Coord_tmp = 0;
            double Z_Coord_tmp = 0;

            double a1W = 0; // Сжатие
            double aW = 0; // Большая полуось
            // Число угловых секунд в радиане
            double ro = 0;

            // Initial conditions ****************************************************
            // Initial conditions

            // Эллипсоид WGS84 (GRS80, эти два эллипсоида сходны по большинству параметров)
            a1W = 1 / 298.257223563; // Сжатие
            aW = 6378137;  // Большая полуось
            // Число угловых секунд в радиане
            ro = 206264.8062;

            // **************************************************** Initial conditions

            // .......................................................................
            // m

            X_Coord_tmp = pointGeocentric.X;
            Y_Coord_tmp = pointGeocentric.Y;
            Z_Coord_tmp = pointGeocentric.Z;
            // .......................................................................

            // N *********************************************************************
            // Квадрат эксцентриситета

            e2_tmp = 2 * a1W - Math.Pow(a1W, 2);
            // ********************************************************************* N

            // Long ******************************************************************
            // Вычсление долготы -> анализ D

            D_tmp = Math.Sqrt(Math.Pow(X_Coord_tmp, 2) + Math.Pow(Y_Coord_tmp, 2));

            // .......................................................................
            // D=0

            if (((int)(D_tmp + 0.5)) == 0)
            {
                geodesic.Longitude = 0;

                if (Z_Coord_tmp != 0)
                    geodesic.Latitude = (Math.PI / 2) * (Z_Coord_tmp / Math.Abs(Z_Coord_tmp));
                else
                    geodesic.Latitude = 0;

                geodesic.Altitude = Z_Coord_tmp * Math.Sin(geodesic.Latitude) -
                          aW * Math.Sqrt(1 - e2_tmp * Math.Pow(Math.Sin(geodesic.Latitude), 2));

                return;

            } // D=0
            // .......................................................................
            // D>0

            else
            {

                La_tmp = Math.Asin(Y_Coord_tmp / D_tmp);
                geodesic.Longitude = La_tmp;

                if ((Y_Coord_tmp < 0) && (X_Coord_tmp > 0))
                    geodesic.Longitude = 2 * Math.PI - La_tmp;
                else if ((Y_Coord_tmp < 0) && (X_Coord_tmp < 0))
                    geodesic.Longitude = 2 * Math.PI + La_tmp;
                else if ((Y_Coord_tmp > 0) && (X_Coord_tmp < 0))
                    geodesic.Longitude = Math.PI - La_tmp;

                // #@#
                else if ((Y_Coord_tmp > 0) && (X_Coord_tmp > 0))
                    geodesic.Longitude = La_tmp;
                else if ((Y_Coord_tmp == 0) && (X_Coord_tmp > 0))
                    geodesic.Longitude = 0;
                else if ((Y_Coord_tmp == 0) && (X_Coord_tmp < 0))
                    geodesic.Longitude = Math.PI;

                //else if ((Y_Coord > 0) && (X_Coord > 0))
                //    Long_Coord = La_tmp;

            } // D>0
            // .......................................................................

            // ***************************************************************** Long

            // Lat,H ****************************************************************
            // Вычисление широты, высоты -> анализ Z

            // .......................................................................
            // Z=0

            if (((int)(Z_Coord_tmp + 0.5)) == 0)
            {
                geodesic.Latitude = 0;
                geodesic.Altitude = D_tmp - aW;

                return;

            } // Z=0
            // .......................................................................
            // Z!=0

            else
            {

                r_tmp = Math.Sqrt(Math.Pow(X_Coord_tmp, 2) + Math.Pow(Y_Coord_tmp, 2) +
                                  Math.Pow(Z_Coord_tmp, 2));

                c_tmp = Math.Asin(Z_Coord_tmp / r_tmp);

                p_tmp = (e2_tmp * aW) / (2 * r_tmp);

                S1_tmp = 0;

                // ????????????????????????????????
                // Количество рад для погрешности delt_d=0.0001угл.с
                delt_d_tmp = 0.0001 / ro;

                b_tmp = c_tmp + S1_tmp;

                if (Math.Sqrt(1 - e2_tmp * Math.Pow(Math.Sin(b_tmp), 2)) > 1E-15)
                    S2_tmp = Math.Asin((p_tmp * Math.Sin(2 * b_tmp)) / (Math.Sqrt(1 - e2_tmp * Math.Pow(Math.Sin(b_tmp), 2))));
                else
                    S2_tmp = Math.Asin((p_tmp * Math.Sin(2 * b_tmp)) / 1E-15);

                d_tmp = Math.Abs(S2_tmp - S1_tmp);

                while (Math.Abs(d_tmp) >= delt_d_tmp)
                {

                    S1_tmp = S2_tmp;

                    b_tmp = c_tmp + S1_tmp;

                    if (Math.Sqrt(1 - e2_tmp * Math.Pow(Math.Sin(b_tmp), 2)) > 1E-15)
                        S2_tmp = Math.Asin((p_tmp * Math.Sin(2 * b_tmp)) / (Math.Sqrt(1 - e2_tmp * Math.Pow(Math.Sin(b_tmp), 2))));
                    else
                        S2_tmp = Math.Asin((p_tmp * Math.Sin(2 * b_tmp)) / 1E-15);

                    d_tmp = Math.Abs(S2_tmp - S1_tmp);

                }; // WHILE

                geodesic.Latitude = b_tmp;

                geodesic.Altitude = D_tmp * Math.Cos(geodesic.Latitude) + Z_Coord_tmp * Math.Sin(geodesic.Latitude) -
                          aW * Math.Sqrt(1 - e2_tmp * Math.Pow(Math.Sin(geodesic.Latitude), 2));


            } // Z!=0
            // .......................................................................

            // **************************************************************** Lat,H

            // ......................................................................
            // Перевод в градусы 

            geodesic.Latitude = (geodesic.Latitude * 180) / Math.PI;
            geodesic.Longitude = (geodesic.Longitude * 180) / Math.PI;
            // ......................................................................


        }
    }
}
