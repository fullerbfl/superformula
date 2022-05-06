using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary.DomainObject
{
    internal class Building
    {
        private List<IRoom> _rooms { get; set; }

        public Building(List<IRoom> rooms)
        {
            _rooms = rooms;
        }

        /// <summary>
        /// Get total volume of all rooms
        /// </summary>
        public double CalcualateVolume()
        {
            // sum up the volume of all rooms
            double volume = 0;
            foreach (var room in _rooms)
            {
                volume += room.CalculateVolume();
            }

            return volume;
        }
    }
}
