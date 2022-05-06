using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary.DomainObject
{
    public class TriangularRoom : IRoom
    {
        double _width { get; set; }
        double _height { get; set; }

        public TriangularRoom(double width, double height)
        {
            _width = width;
            _height = height;
        }
        public double CalculateVolume()
        {
            return Core.VolumeMath.PyramidVolume(_width, _height);
        }
    }
}
