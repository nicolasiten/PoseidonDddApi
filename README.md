# PoseidonDddApi
.Net Core Web API to perform CRUD operations on a set of objects.
# Projects
## Project Structure: Domain Driven Design
## PoseidonTradeDddApi.Infrastructure
- Data Access Logic
	- EF Migrations
	- Ef DbContext 
- IdentityServer Configuration and Setup
## PoseidonTradeDddApi.Domain
- Domain Layer
	- Objects specific to the Domain Layer (Entities, Constants)
## PoseidonTradeDddApi.Application
- Application Layer 
	- Dependent on Domain Layer
	- Contains all application logic
	- Defines interfaces implemented by outside layers
## PoseidonTradeDddApi.Api
- WebApi project
# Comments
## DB Access - CQRS
For the DB Access the CQRS pattern is implemented. Each command has it's own input/output entity and is completely independent. Input objects (TRequest) get mapped automatically to entity objects thank's to the use of Automapper.
## Mediator
To have the frontend as loosely coupled as possible the MediatR Library is used. Thank's to the ApiController Base Controller the Controllers have zero dependencies.
## Middleware
### Exception Handling
There's an exception handler middleware (CustomExceptionHandlerMiddleware.cs) which sends specific Return HttpCodes on certain Exceptions.
### Request Logging
Each Request to the Backend through MediatR gets logged thank's to the RequestLogger.cs.
### Validation
For Each Request to the Backend through MediatR the RequestValidationBehaviour.cs automatically checks if there are validators (FluentValidation) defined for the sent entities, if there are any they get validated.