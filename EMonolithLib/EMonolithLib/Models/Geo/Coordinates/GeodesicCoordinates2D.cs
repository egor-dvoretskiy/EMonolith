using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Models.Geo.Coordinates
{
    public class GeodesicCoordinates2D
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public sealed override string ToString()
        {
            return string.Format("{0}, {1}", Latitude, Longitude);
        }
    }
}
