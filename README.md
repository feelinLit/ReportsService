# ReporstService

- [ReporstService](#reporstservice)
  - [:thinking: What is this](#thinking-what-is-this)
  - [:wrench: Implementation details](#wrench-implementation-details)
  - [:framed_picture: How it looks](#framed_picture-how-it-looks)
  - [:rocket: How to run with Docker](#rocket-how-to-run-with-docker)

## :thinking: What is this

This project was meant for __C# education purposes__.  
The initial idea was to implement a __multi-layered MVC application__ with __well designed architecture__ and __the most useful approaches__.

## :wrench: Implementation details

The aim of _ReportsService_ is to let __Employees__ create a __Report__ on __Problems__ assigned to them. An __Employee__ can have __Subordinates__ and __Supervisor__, so the structure is a tree(can be a forest) with __TeamLead__ being a root. Also __Employees__ are able to add multiple __Comments__ to assigned __Problems__ in case they want to show the progress or to left some notes.  

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

## :framed_picture: How it looks  

__Swagger:__  
<img src="https://user-images.githubusercontent.com/79377488/171019249-c0defb08-a13a-40d8-b345-a755cfd13930.png" width="900">
<img src="https://user-images.githubusercontent.com/79377488/171019342-38efacf2-b044-4f0a-98a4-3bbcf2c1182c.png" width="900">

__Visuals:__  
<img src="https://user-images.githubusercontent.com/79377488/171019784-5c0060a9-7472-4dfd-9f27-c78b2f91d544.png" width="900">
<img src="https://user-images.githubusercontent.com/79377488/171019863-7a0feeca-288d-4b4c-b779-b937c8bb735f.png" width="900">

## :rocket: How to run with Docker

1. Download file ``docker-compose.yml`` from this repo
2. Place it in empty folder __named in english__
3. Start console from created directive
4. Run command ```docker compose up```
5. Wait until docker images are pulled  

Now you should be able to open ```localhost:8000``` and see the result!

If ```localhost:8000``` isn't available - run command ```docker compose start web``` to restart the container with the _web_ service.
