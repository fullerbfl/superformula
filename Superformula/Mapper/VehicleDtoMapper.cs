using Superformula.Api.DTO;
using Superformula.Core.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace Superformula.Api.Mapper
{
    public static class VehicleDtoMapper
    {
        public static Vehicle MapToDO(this VehicleDto vehicle)
        {
            if(vehicle == null) 
                return null;

            return new Vehicle()
            {
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,  
                VehicleName = vehicle.VehicleName,
                Year = vehicle.Year
            };

        }

    }
}