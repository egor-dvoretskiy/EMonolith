using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Models.Geo.Coordinates
{
    /// <summary>
    /// Spherical coordinates/parameters.
    /// </summary>
    public class SphericalCoordinates
    {
        /// <summary>
        /// Radial distance to point, measures in meters.
        /// </summary>
        public double RadialDistance { get; set; }

        /// <summary>
        /// Zenith to point, measures in degrees.
        /// </summary>
        public double Zenith { get; set; }

        /// <summary>
        /// Azimuth to point, measures in degrees.
        /// </summary>
        public double Azimuth { get; set; }
    }
}
