using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary.DomainObject
{
    public class CubicalRoom : IRoom
    {
        private double _length { get; set; }
        private double _width { get; set; }
        private double _height { get; set; }

        public CubicalRoom(double length, double width, double height)
        {
            _length = length;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Get the volume of the Cubical
        /// </summary>
        public double CalculateVolume()
        {
            return Core.VolumeMath.RectangleVolume(_length, _width, _height);
        }
    }



}
