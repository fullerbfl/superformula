using NUnit.Framework;
using Superformula.Core.DomainModel;
using Superformula.Service;
using System;

namespace Superformula.Tests1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddPolicy()
        {
            var service = new InsurancePolicyService();

            var policyId = service.SavePolicy(new InsurancePolicy()
            {
                Address = "tampa, fl",
                DriversLicenseNumber = "FL 123",
                FirstName = "John",
                LastName = "Doe",
                EffectiveDate = DateTime.Today,
                ExpirationDate = DateTime.Today.AddYears(5),
                Premium = 5000000,
                Vehicle = new Vehicle()
                {
                    Manufacturer = "Bugati",
                    Model = "Fast",
                    VehicleName = "Car1",
                    Year = DateTime.Parse("1998-1-1")
                }
            });

        }

    }
}