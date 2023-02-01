using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Maths.Source
{
    public class DegreeConverter
    {
        public static double DegreesToRadians(double degree)
        {
            return (degree * Math.PI / 180.0);
        }

        public static double RadiansToDegrees(double radians)
        {
            return (radians / Math.PI * 180.0);
        }
    }
}
