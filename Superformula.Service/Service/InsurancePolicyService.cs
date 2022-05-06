using Superformula.Core.DomainModel;
using Superformula.Core.Enum;
using Superformula.Persistence.Repository;
using Superformula.Service.Interface;

namespace Superformula.Service
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private InsurancePolicyRepository _insurancePolicyRepository;
        private StateRegulationService _stateRegulationService;


        public InsurancePolicyService(InsurancePolicyRepository insurancePolicyRepository, StateRegulationService stateRegulationService)
        {
            _insurancePolicyRepository = insurancePolicyRepository;
            _stateRegulationService = stateRegulationService;
        }

        /// <summary>
        /// Try to save a policy
        /// </summary>
        public async Task<Tuple<InsurancePolicy, string>> SavePolicy(InsurancePolicy policy)
        {
            // validate state regulations
            var response = "";
            var validPolicy = _stateRegulationService.IsValidPolicy(policy, out response);

            if (!validPolicy)
                return new Tuple<InsurancePolicy, string>(null, response);

            // save it
            var result = _insurancePolicyRepository.SavePolicy(policy);

            // call state regulatory notification service - do not await this call


            ThreadPool.QueueUserWorkItem((p) =>
            {
                _stateRegulationService.RegisterThisPolicy(policy);
            });


            return new Tuple<InsurancePolicy, string>(result, response);
        }

        public List<InsurancePolicy> GetPolicies(string driversLicenseNum, string vechicleYearSort = "Asc", bool includeExpiredPolicy = false)
        {
            return _insurancePolicyRepository.GetPolicies(driversLicenseNum, vechicleYearSort, includeExpiredPolicy);
        }

        public InsurancePolicy GetPolicy(int policyId, string driversLicenseNum)
        {
            return _insurancePolicyRepository.GetPolicy(policyId, driversLicenseNum);
        }
    }
}
