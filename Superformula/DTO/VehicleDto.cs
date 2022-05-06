using System.ComponentModel.DataAnnotations;

namespace Superformula.Api.DTO
{
    public class VehicleDto
    {
        [Required]
        [Range(0, 2030)]
        public int Year { get; set; }

        [Required]
        public string  Model { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string VehicleName { get; set; }

    }
}