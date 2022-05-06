using System.ComponentModel.DataAnnotations;

namespace Superformula.Api.DTO
{
    public class InsurancePolicyDto
    {
        public int PolicyId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }

        [Required]
        public string DriversLicenseNumber { get; set; }

        [Required]
        public VehicleDto Vehicle { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Address is not valid.")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public decimal Premium { get; set; }

    }
}
