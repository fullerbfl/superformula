using Superformula.Api.DTO;
using Superformula.Core.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace Superformula.Api.Mapper
{
    public static class InsurancePolicyDtoMapper
    {
        public static InsurancePolicy MapToDO(this InsurancePolicyDto policy)
        {
            if(policy  == null) 
                return null;

            return new InsurancePolicy()
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

    }
}