Written using Visual Studio 2022 .net 6
The main solution file is  /Superformula/Superformula.sln

Open the solution in Visual Studio and make sure the "Superformula.Api" project is set as the StartUp project.
Run the project.  This should start a web browser with a Swagger page that will allow you to view the entire API and test it out.

Enjoy.



Onboarding:

The best way to see how to consume this API is to use the Swagger page.  This will show each endpoint, which verb to use and give sample DTOs.  It also allows testing the API to see how it responds to differing inputs.


State Regulations method:
If another team were to take on the State Regulations module, I would make sure it is well documented and has a sufficient amount of test coverage.  This should allow the team to see what requirements went in to building the module and will allow them to see the various ways in which to consume it.


Productionizing the code:
1. Security should be applied to the middleware and endpoints.  If you wait too long, then it will be much harder to secure the API.  
2. Make sure logging is in place from the beginning.  Many times a project is started and logging is an after-thought and ends up being bolted on at the end.
3. Maintain clean and clear separation of each layer of the code.  This will allow much more flexibility when adding features and will also allow the assemblies to be used by other consumers and not just the API layer.
4. Start to think about adding multi-tenancy to the code so that different customers can use the same codebase and deployment.



Running the code on a cloud provider:
To run the cloud on the cloud I would recommend using Azure app services (or functions if you want to consider microservices) with a sql database repository.  There are many flavors of sql, but a simple Azure Sql Database would suffice.  Within Azure there are many considerations to make such as how to configure each environment (dev, uat, prod), what type of security is needed (app gateway, certificates, vlans, key vaults, IAM, etc), and how the general architecture is layed out.

You'll want to get the code into a repository and configure a CI/CD mechanism for continous testing and deployment.  This will greatly ease the burden of deployment and allow the dev team to be extremely productive.  Also, consider a multi-tenant approach to the code (thread safety, separation of data, routing, etc) to allow multiple customers to consume the API.

