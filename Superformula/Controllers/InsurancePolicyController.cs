using Microsoft.AspNetCore.Mvc;
using Superformula.Api.DTO;
using Superformula.Api.Mapper;
using Superformula.Service;
using Superformula.Service.Interface;
using System.Text.RegularExpressions;

namespace Superformula.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly ILogger<InsurancePolicyController> _logger;
        private readonly IInsurancePolicyService _insurancePolicyService;

        public InsurancePolicyController(IInsurancePolicyService insurancePolicyService, ILogger<InsurancePolicyController> logger)
        {
            _logger = logger;
            _insurancePolicyService = insurancePolicyService;
        }

        [HttpGet("{policyId}")]
        public IActionResult GetPolicy(int policyId, string driversLicenseNumber)
        {
            var policy = _insurancePolicyService.GetPolicy(policyId, driversLicenseNumber);

            if (policy == null)
                return NotFound();

            return Ok(policy);
        }

        [HttpGet]
        public IActionResult GetPolicies(string driversLicenseNumber, string vechicleYearSort, bool includeExpiredPolicy)
        {
            var policy = _insurancePolicyService.GetPolicies(driversLicenseNumber, vechicleYearSort, includeExpiredPolicy);

            if (policy == null)
                return NotFound();

            return Ok(policy);
        }

        [HttpPost]
        public async Task<IActionResult> Save(InsurancePolicyDto policy)
        {
            // validation
            var regex = new Regex(@"^[\w\s]+,\s[A-Z]{2}\s{1}\d{5}(-\d{4})?$");
            if (false == regex.IsMatch(policy.Address))
                return BadRequest("Invalid address");

            if (policy.Vehicle == null)
                return BadRequest("Vehicle data is required");

            if (policy.EffectiveDate < DateTime.Now.AddDays(30))
                return BadRequest("Effective Date must be at least 30 days in the future");

            if (policy.Vehicle.Year >= 1998)
                return BadRequest("Vehicle Year should be before 1998.");


            // save the policy
            var response = await _insurancePolicyService.SavePolicy(policy.MapToDO());
            if (response != null && response.Item1 == null)
                return Conflict(response.Item2);

            return Created("", response?.Item1);
        }

    }
}