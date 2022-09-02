using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Models.Geo.Coordinates
{
    /// <summary>
    /// Class for coordinates representation in local terestrial and geocentral CS's.
    /// </summary>
    public class CartesianCoordinates
    {
        /// <summary>
        /// Planar coordinate X.
        /// </summary>
        public double x { get; set; }

        /// <summary>
        /// Planar coordinate Y, usually Altitude.
        /// </summary>
        public double y { get; set; }

        /// <summary>
        /// Planar coordinate Z.
        /// </summary>
        public double z { get; set; }
    }
}
