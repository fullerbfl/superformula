using Superformula.Core.DomainModel;
using Superformula.Core.Enum;

namespace Superformula.Service.Interface
{
    public interface IInsurancePolicyService
    {
        public Task<Tuple<InsurancePolicy, string>> SavePolicy(InsurancePolicy policy);

        public List<InsurancePolicy> GetPolicies(string driversLicenseNum, string vechicleYearSort, bool includeExpiredPolicy = false);

        public InsurancePolicy GetPolicy(int policyId, string driversLicenseNum);
    }
}
