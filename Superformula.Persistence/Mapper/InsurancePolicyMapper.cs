using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superformula.Persistence.Mapper
{
    public static class InsurancePolicyMapper
    {
        /// <summary>
        /// Map persistence model to domain model
        /// </summary>
        public static Core.DomainModel.InsurancePolicy MapToDO(this Model.InsurancePolicy policy)
        {
            if (policy == null)
                return null;

            return new Core.DomainModel.InsurancePolicy()
            {
                PolicyId = policy.PolicyId,
                DriversLicenseNumber = policy.DriversLicenseNumber,
                Address = policy.Address,
                EffectiveDate = policy.EffectiveDate,
                ExpirationDate = policy.ExpirationDate,
                FirstName = policy.FirstName,
                LastName = policy.LastName,
                Premium = policy.Premium,
                Vehicle = policy.Vehicle?.MapToDO()
            };

        }

        /// <summary>
        /// Map persistence model to domain model
        /// </summary>
        public static List<Core.DomainModel.InsurancePolicy> MapToDO(this List<Model.InsurancePolicy> policy)
        {
            if (policy == null)
                return null;

            return policy.Select(p => new Core.DomainModel.InsurancePolicy()
            {
                PolicyId  = p.PolicyId,
                DriversLicenseNumber = p.DriversLicenseNumber,
                Address = p.Address,
                EffectiveDate = p.EffectiveDate,
                ExpirationDate = p.ExpirationDate,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Premium = p.Premium,
                Vehicle = p.Vehicle?.MapToDO()
            }).ToList();
        }


    }
}
