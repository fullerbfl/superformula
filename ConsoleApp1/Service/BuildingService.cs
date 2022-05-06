using BuildingLibrary.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary.Service
{
    internal class BuildingService
    {
        /// <summary>
        /// Sum up the total volume for all buildings
        /// </summary>
        public double CalculateTotalVolume(List<Building> buildings)
        {
            double totalVolume = 0;
            foreach (Building building in buildings)
            {
                totalVolume += building.CalcualateVolume();
            }

            return totalVolume;
        }
    }
}
