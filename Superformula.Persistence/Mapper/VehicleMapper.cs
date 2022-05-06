using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superformula.Persistence.Mapper
{
    public static class VehicleMapper
    {
        public static Core.DomainModel.Vehicle MapToDO(this Model.Vehicle vehicle)
        {
            if (vehicle == null)
                return null;

            return new Core.DomainModel.Vehicle()
            {
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                VehicleName = vehicle.VehicleName,
                Year = vehicle.Year
            };

        }

    }

}
