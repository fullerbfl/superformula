using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary.Core
{
    internal static class VolumeMath
    {
        public static double RectangleVolume(double length, double width, double height)
        {
            return length * width * height;
        }

        public static double PyramidVolume(double sideLength, double height)
        {
            return (.33333333 * (sideLength * sideLength) * height);
        }

        public static double CylinderVolume(double height, double radius)
        {
            return 3.14159265 * (radius * radius) * height;
        }
    }
}
