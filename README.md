# ReporstService

- [ReporstService](#reporstservice)
  - [:thinking: What is this](#thinking-what-is-this)
  - [:wrench: Implementation details](#wrench-implementation-details)
  - [:rocket: How to run](#rocket-how-to-run)

## :thinking: What is this

This project was meant for __C# education purposes__.  
The initial idea was to implement a __multi-layered MVC application__ with __well designed architecture__ and __the most useful approaches__.

## :wrench: Implementation details

The __architecture__ is pretty simple:

![Database diagram](https://user-images.githubusercontent.com/79377488/169649273-b2287e1a-a6ca-4d31-a701-c5c74e261e93.png "Database diagram")  

![Dependencies diagram](https://user-images.githubusercontent.com/79377488/169649200-82d07045-fee1-4853-a961-df00af636058.png "Solution dependencies diagram")

`/src`  

- __Reports.DAL__ &ndash; handles communication with _Database_ through EF Core  

- __Reports.Domain__ &ndash;  contains _Business Logic_ with _Rich Domain Objects_ and simple _Services_ requesting data from DAL and responding with View Models  

- __Reports.Shared__ &ndash; stores _Data Transfer Objects_ with which different layers communicate with each other  

- __Reports.API__ &ndash; contains _Controllers_ handling HTTP requests (ASP.NET Core)

- __Reports.Client__  &ndash; _presentation layer_ using Blazor Server

`/test`  

- __Reports.Tests.UnitTests__ &ndash; Unit tests for Domain Layer (xUnit + Moq)

- __Reports.Tests.IntegrationTests__ &ndash; testing the integration of all modules

## :rocket: How to run
