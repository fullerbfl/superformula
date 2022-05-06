using Superformula.Core.DomainModel;
using Superformula.Core.Enum;
using Superformula.Persistence.Repository;

namespace Superformula.Service
{
    public class StateRegulationService
    {
        public bool IsValidPolicy(InsurancePolicy policy, out string response)
        {
            var random = new Random();
            var randomNumber = random.Next(1, 200);

            switch (randomNumber)
            {
                case var n when n > 100:
                    response = "State regulations don't allow this policy.";
                    return false;

                default:
                    response = "Policy is valid";
                    return true;
            }
        }

        /// <summary>
        /// Register this policy with the state
        /// </summary>
        public async Task RegisterThisPolicy(InsurancePolicy policy)
        {
            // use a random number to simulate a success or failure
            var random = new Random();
            var randomNumber = random.Next(1, 200);

            if (randomNumber <= 100) // failure
            {
                // retry three times
                for (var i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000); // processing the request
                    randomNumber = random.Next(1, 200);

                    if (randomNumber > 100) // success
                        break;
                }
            }

        }
    }
}
