# .NET Core Leave Management System For Learning Purpose
This repository contains the source code for .NET Core Leave Management System built using Clean Architecture.
The project uses CQRS, AutoMapper, Blazor, .NET API, and EF Core. It also includes unit and integration tests.

## Table of Contents

- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Code Samples](#code-samples)
- [Documentation](#documentation)
- [Contributing](#contributing)
- [License](#license)

## Technologies

The project uses the following technologies:

- .NET Core (8)
- CQRS
- AutoMapper
- Blazor
- .NET API
- EF Core
- xUnit
- Moq

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file in Visual Studio or another IDE of your choice.
3. Restore the NuGet packages.
4. Set the startup projects to `HRLeaveManagement.Api` and `HRLeaveManagement.BlazorUI`.
5. Run the project.

## Project Structure

The project is organized using the Clean Architecture principles. The solution is composed of the following projects:

- `HRLeaveManagement.Application`: Contains the application layer of the project, which contains the application logic and interfaces.
- `HRLeaveManagement.Domain`: Contains the domain layer of the project, which contains the domain models and business rules.
- `HRLeaveManagement.Infrastructure`: Contains the infrastructure layer of the project, which contains the implementation of the interfaces defined in the application layer.
- `HRLeaveManagement.Api`: Contains the API layer of the project
- `HRLeaveManagement.BlazorUI`: Contains the Blazor client application

## Code Samples

The project contains code samples for several areas of .NET Core development, including:

- CQRS
- AutoMapper
- Blazor
- .NET API
- EF Core
- Unit Testing
- Integration Testing

Each project and code sample is well-documented, and the code is designed to be easy to read and follow.
