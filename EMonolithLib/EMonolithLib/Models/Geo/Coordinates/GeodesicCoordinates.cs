using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Models.Geo.Coordinates
{
    /// <summary>
    /// Coordinates used in WGS84.
    /// </summary>
    public class GeodesicCoordinates
    {
        /// <summary>
        /// Latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Altitude.
        /// </summary>
        public double Altitude { get; set; }

        public sealed override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Latitude, Longitude, Altitude);
        }
    }
}
