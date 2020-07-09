# Havbruksloggen.CodingChallenge

https://havbruksloggencodingchallengeapi20200705154032.azurewebsites.net/swagger


Havbruksloggen.CodingChallenge.API

https://havbruksloggencodingchallengeapi20200705154032.azurewebsites.net/swagger

## Source code contains

* [Autofac](https://autofac.org/)
* [Swagger](https://swagger.io/) + [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle)
* [EF Core](https://docs.microsoft.com/ef/)
    * [MsSQL from Microsoft](https://github.com/aspnet/EntityFrameworkCore/)
* Tests
    * Integration tests with InMemory database
        * [FluentAssertions]
        * [xUnit]
    * Unit tests
        * [AutoFixture](https://github.com/AutoFixture/AutoFixture)
        * [FluentAssertions]
        * [Moq](https://github.com/moq/moq4)
        * [Moq.AutoMock](https://github.com/moq/Moq.AutoMocker)
        * [xUnit]
    * Load tests
        * [FluentAssertions]
        * [NBomber](https://nbomber.com/)
        * [xUnit]

* [Serilog](https://serilog.net/)
    * Sink: [Async](https://github.com/serilog/serilog-sinks-async)
    * Enrich: [CorrelationId](https://github.com/ekmsystems/serilog-enrichers-correlation-id)

## Architecture

### Api

  * Startup class - [Startup.cs]
  * MvcCore
  * DbContext (with MsSQL)
  * Swagger and SwaggerUI (Swashbuckle)
  * HostedService
  * HttpClient
* Filters
  * Action filter to validate `ModelState` - [ValidateModelStateFilter.cs]
  * Global exception filter - [HttpGlobalExceptionFilter.cs]
* Configurations
  * Dependency registration place - [ContainerConfigurator.cs]
  * `Serilog` configuration place - [SerilogConfigurator.cs]
  * `Swagger` configuration place - [SwaggerConfigurator.cs]

### Core


* Simple MsSQL AppDbContext - [AppDbContext.cs]
* Services
* Repositories
* Entities
* Extensions
* EF Core Migrations

## Tests

### Integration tests

### Unit tests

## Build the solution

Execute `dotnet build` in the root directory, it takes `Havbruksloggen.CodingChallenge.sln` and build everything.
Or pick Havbruksloggen.CodingChallenge.Api as startup project and run the console application

## Deployed on Azure

https://havbruksloggencodingchallengeapi20200705154032.azurewebsites.net/swagger

## Azure blob container integration

For Image upload feature craeted azure blob container

