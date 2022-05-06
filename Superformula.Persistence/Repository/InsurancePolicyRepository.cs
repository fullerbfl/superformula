using Superformula.Core.Enum;
using Superformula.Persistence.Mapper;
using Superformula.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superformula.Persistence.Repository
{
    public class InsurancePolicyRepository
    {
        private List<InsurancePolicy> Policies;

        public InsurancePolicyRepository()
        {
            Policies = new List<InsurancePolicy>();
        }

        /// <summary>
        /// Get insurance policy
        /// </summary>
        public Core.DomainModel.InsurancePolicy GetPolicy(int policyId, string driversLicenseNumber)
        {
            // get the policy
            var policy = Policies.FirstOrDefault(p =>
                p.PolicyId == policyId &&
                 p.DriversLicenseNumber.Equals(driversLicenseNumber, StringComparison.OrdinalIgnoreCase) 
                );

            return policy.MapToDO();
        }

        /// <summary>
        /// Get insurance policies for the given drivers license
        /// </summary>
        public List<Core.DomainModel.InsurancePolicy> GetPolicies(string driversLicenseNumber, string vehicleYearSort, bool excludeExpired = false)
        {
            // get the policies
            var policies = Policies.Where(p =>
                 p.DriversLicenseNumber.Equals(driversLicenseNumber, StringComparison.OrdinalIgnoreCase) &&
                 ((excludeExpired == true && p.EffectiveDate < DateTime.Now) || (excludeExpired == false && p.EffectiveDate >= DateTime.Now))
                ).ToList();

            // sort
            if (vehicleYearSort.Equals(VehicleYearSort.Desc.ToString(), StringComparison.OrdinalIgnoreCase))
                policies = policies.OrderByDescending(p => p.Vehicle.Year).ToList();
            else
                policies = policies.OrderBy(p => p.Vehicle.Year).ToList();

            return policies.MapToDO();
        }

        /// <summary>
        /// Save the insurance policy
        /// </summary>
        public Core.DomainModel.InsurancePolicy SavePolicy(Core.DomainModel.InsurancePolicy policy)
        {
            // get the latest ID
            var id = (Policies.OrderByDescending(p => p.PolicyId).FirstOrDefault()?.PolicyId ?? 0) + 1;

            // save the policy
            var result = new InsurancePolicy
            {
                PolicyId = id,
                Premium = policy.Premium,
                Address = policy.Address,
                DriversLicenseNumber = policy.DriversLicenseNumber,
                EffectiveDate = policy.EffectiveDate,
                ExpirationDate = policy.ExpirationDate,
                FirstName = policy.FirstName,
                LastName = policy.LastName,
                Vehicle = new Vehicle()
                {
                    Manufacturer = policy.Vehicle.Manufacturer,
                    Model = policy.Vehicle.Model,
                    VehicleName = policy.Vehicle.VehicleName,
                    Year = policy.Vehicle.Year,
                }
            };
            Policies.Add(result);

            return result.MapToDO();
        }

    }
}
