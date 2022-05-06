using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using Superformula.Api.Controllers;
using Superformula.Api.DTO;
using Superformula.Core.DomainModel;
using Superformula.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superformula.Service.Tests
{
    [TestClass()]
    public class InsurancePolicyControllerTests
    {
        private InsurancePolicyService _insurancePolicyService;
        public InsurancePolicyControllerTests()
        {
            _insurancePolicyService = GetInsurancePolicyService();
        }

        [TestMethod()]
        public void AddPolicyVehicleTooNewTest()
        {

            var controller = new InsurancePolicyController(_insurancePolicyService, null);
            var policy = controller.Save(new InsurancePolicyDto()
            {
                Address = "Tampa, FL 97005",
                DriversLicenseNumber = "FL 123",
                FirstName = "John",
                LastName = "Doe",
                EffectiveDate = DateTime.Today.AddDays(40),
                ExpirationDate = DateTime.Today.AddYears(5),
                Premium = 5000000,
                Vehicle = new VehicleDto()
                {
                    Manufacturer = "Bugati",
                    Model = "Fast",
                    VehicleName = "Car1",
                    Year = 2022
                }
            }).Result;

            (policy as BadRequestObjectResult).Value.ShouldBe("Vehicle Year should be before 1998.");
        }

        [TestMethod()]
        public void AddPolicyInvalidExpectedDateTest()
        {
            var controller = new InsurancePolicyController(_insurancePolicyService, null);
            var policy = controller.Save(new InsurancePolicyDto()
            {
                Address = "Tampa, FL 97005",
                DriversLicenseNumber = "FL 123",
                FirstName = "John",
                LastName = "Doe",
                EffectiveDate = DateTime.Now,
                ExpirationDate = DateTime.Today.AddYears(5),
                Premium = 5000000,
                Vehicle = new VehicleDto()
                {
                    Manufacturer = "Bugati",
                    Model = "Fast",
                    VehicleName = "Car1",
                    Year = 1997
                }
            }).Result;

            (policy as BadRequestObjectResult).Value.ShouldBe("Effective Date must be at least 30 days in the future");
        }

        [TestMethod()]
        public void AddPolicyInvalidAddressTest()
        {
            var controller = new InsurancePolicyController(_insurancePolicyService, null);
            var policy = controller.Save(new InsurancePolicyDto()
            {
                Address = "&&^551",
                DriversLicenseNumber = "FL 123",
                FirstName = "John",
                LastName = "Doe",
                EffectiveDate = DateTime.Now.AddDays(40),
                ExpirationDate = DateTime.Today.AddYears(5),
                Premium = 5000000,
                Vehicle = new VehicleDto()
                {
                    Manufacturer = "Bugati",
                    Model = "Fast",
                    VehicleName = "Car1",
                    Year = 1997
                }
            }).Result;

            (policy as BadRequestObjectResult).Value.ShouldBe("Invalid address");
        }

        [TestMethod()]
        public void GetPolicyTest()
        {
            var controller = new InsurancePolicyController(_insurancePolicyService, null);
            var insurancePolicy = new InsurancePolicyDto()
            {
                Address = "Tampa, FL 97005",
                DriversLicenseNumber = "FL 123",
                FirstName = "John",
                LastName = "Doe",
                EffectiveDate = DateTime.Now.AddDays(40),
                ExpirationDate = DateTime.Today.AddYears(5),
                Premium = 5000000,
                Vehicle = new VehicleDto()
                {
                    Manufacturer = "Bugati",
                    Model = "Fast",
                    VehicleName = "Car1",
                    Year = 1997
                }
            };

            // try to save a policy - repeat 5 times if it fails
            object result;
            var numTries = 0;
            do
            {
                result = controller.Save(insurancePolicy).Result;
            }
            while (!(result is CreatedResult) && ++numTries <= 5);


            // if the policy was created
            if(result is CreatedResult)
            {
                // retrieve the policy
                var policy = ((result as CreatedResult).Value as InsurancePolicy);
                var retrievedPolicy = controller.GetPolicy(policy.PolicyId, policy.DriversLicenseNumber);

                // validate
                retrievedPolicy.GetType().ShouldBe(typeof(OkObjectResult));
                ((retrievedPolicy as OkObjectResult).Value as InsurancePolicy).PolicyId.ShouldBe(policy.PolicyId);
            }
        }

        [TestMethod()]
        public void GetPolicyMismatchWithDriversLicenseIdTest()
        {
            var controller = new InsurancePolicyController(_insurancePolicyService, null);
            var insurancePolicy = new InsurancePolicyDto()
            {
                Address = "Tampa, FL 97005",
                DriversLicenseNumber = "FL 123",
                FirstName = "John",
                LastName = "Doe",
                EffectiveDate = DateTime.Now.AddDays(40),
                ExpirationDate = DateTime.Today.AddYears(5),
                Premium = 5000000,
                Vehicle = new VehicleDto()
                {
                    Manufacturer = "Bugati",
                    Model = "Fast",
                    VehicleName = "Car1",
                    Year = 1997
                }
            };

            // try to save a policy - repeat 5 times if it fails
            object result;
            var numTries = 0;
            do
            {
                result = controller.Save(insurancePolicy).Result;
            }
            while (!(result is CreatedResult) && ++numTries <= 5);


            // if the policy was created
            if (result is CreatedResult)
            {
                // retrieve the policy
                var policy = ((result as CreatedResult).Value as InsurancePolicy);
                var retrievedPolicy = controller.GetPolicy(policy.PolicyId, "some other drivers license id");

                // validate
                retrievedPolicy.GetType().ShouldBe(typeof(NotFoundResult));
            }
        }

        private InsurancePolicyService GetInsurancePolicyService()
        {
            return new InsurancePolicyService(new Persistence.Repository.InsurancePolicyRepository(), new StateRegulationService());
        }

    }
}