using EMonolithLib.Models.Geo.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Models.Geo
{
    /// <summary>
    /// Representation of point in different CS's.
    /// </summary>
    public class Point3D
    {
        /// <summary>
        /// Geodesic CS, WGS84.
        /// </summary>
        public GeodesicCoordinates Geodesic { get; set; } = new GeodesicCoordinates();

        /// <summary>
        /// Geocentric CS.
        /// </summary>
        public CartesianCoordinates Geocentric { get; set; } = new CartesianCoordinates();

        /// <summary>
        /// Local terestrial CS.
        /// </summary>
        public CartesianCoordinates LocalTerestrial { get; set; } = new CartesianCoordinates();

        /// <summary>
        /// Spherical CS.
        /// </summary>
        public SphericalCoordinates Spherical { get; set; } = new SphericalCoordinates();
    }
}
