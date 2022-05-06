namespace Superformula.Core.DomainModel
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public DateTime EffectiveDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DriversLicenseNumber { get; set; }

        public Vehicle? Vehicle { get; set; }

        public string Address { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Premium { get; set; }

    }
}
