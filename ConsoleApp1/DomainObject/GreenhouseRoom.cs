using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary.DomainObject
{
    public class GreenhouseRoom : IRoom
    {
        private double _length { get; set; }
        private double _width { get; set; }
        private double _height { get; set; }
        private double _radius => _width / 2;

        public GreenhouseRoom(double length, double width, double height)
        {
            _length = length;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Get the volume of the Greenhouse
        /// </summary>
        public double CalculateVolume()
        {
            // assuming the roof is a half cylinder - calculate the cylinder volume and take half of it
            var roofVolume = Core.VolumeMath.CylinderVolume(_height, _radius) / 2;

            // get the volume of the building - not including the roof
            var buildingFrameVolume = Core.VolumeMath.RectangleVolume(_length, _width, _height);

            // return total volume
            return roofVolume + buildingFrameVolume;
        }
    }
}
