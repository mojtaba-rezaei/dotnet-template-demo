# Contica Azure Function App Template

A `dotnet new` template for creating **.NET 10 isolated-process Azure Function Apps** following Contica enterprise standards.

## Features

- **Modern .NET 10** with isolated worker process model
- **Multiple trigger types** - HTTP, Blob, Service Bus, Timer, and Queue triggers
- **Clean architecture** - Thin functions with business logic in services
- **Dependency injection** - Extension methods for service registration
- **Exception handling middleware** - Centralized error handling
- **Unit tests included** - xUnit + NSubstitute + FluentAssertions
- **EditorConfig enforced** - Consistent code style across the team
- **Flexible project structure** - Include/exclude solution and test projects

## Installation

```bash
dotnet new install contica.templates.func
```

## Quick Start

```bash
# Create a new function app with default HTTP trigger
dotnet new contica-func -n MyFunctionApp

# Navigate and run
cd MyFunctionApp/src
dotnet run --project MyFunctionApp-FunctionApp
```

## Usage Options

### Trigger Types

Select which trigger samples to include:

| Parameter | Default | Description |
|-----------|---------|-------------|
| `--HttpTrigger` | `true` | HTTP trigger (GET /api/time) |
| `--BlobTrigger` | `false` | Blob storage trigger |
| `--ServiceBusTrigger` | `false` | Service Bus queue trigger |
| `--TimerTrigger` | `false` | Timer/CRON trigger |
| `--QueueTrigger` | `false` | Storage queue trigger |

### Project Structure

| Parameter | Default | Description |
|-----------|---------|-------------|
| `--IncludeSolution` | `true` | Include .slnx solution file |
| `--IncludeTests` | `true` | Include xUnit test project |

### Examples

```bash
# Full project with multiple triggers
dotnet new contica-func -n MyApp --BlobTrigger --ServiceBusTrigger

# Function app only (add to existing solution)
dotnet new contica-func -n MyApp --IncludeSolution false --IncludeTests false

# With all triggers
dotnet new contica-func -n MyApp --HttpTrigger --BlobTrigger --ServiceBusTrigger --TimerTrigger --QueueTrigger
```

## Generated Project Structure

```
MyFunctionApp/
├── src/
│   ├── MyFunctionApp.slnx
│   ├── .editorconfig
│   └── MyFunctionApp-FunctionApp/
│       ├── MyFunctionApp-FunctionApp.csproj
│       ├── Program.cs
│       ├── host.json
│       ├── local.settings.json-template
│       ├── Configuration/
│       │   └── Constants.cs
│       ├── Extensions/
│       │   └── ServiceCollectionExtensions.cs
│       ├── Functions/
│       │   └── TimeFunction.cs (+ other triggers)
│       ├── Middleware/
│       │   └── ExceptionHandlingMiddleware.cs
│       ├── Models/
│       │   └── TimeResponse.cs (+ other models)
│       └── Services/
│           ├── ITimeService.cs
│           └── TimeService.cs (+ other services)
└── tests/
    └── MyFunctionApp.FunctionApp.Tests/
        ├── MyFunctionApp.FunctionApp.Tests.csproj
        └── Unit/
            ├── TimeFunctionTests.cs
            └── TimeServiceTests.cs
```

## Requirements

- .NET 10 SDK
- Azure Functions Core Tools (for local development)

## Local Development

1. Copy `local.settings.json-template` to `local.settings.json`
2. Run with Azure Functions Core Tools:
   ```bash
   func start
   ```
   Or with .NET CLI:
   ```bash
   dotnet run
   ```

## License

Copyright © Contica AB 2026

## Links

- [Contica AB](https://github.com/Contica-AB)
- [Azure Functions Documentation](https://docs.microsoft.com/azure/azure-functions/)
- [.NET Isolated Worker Guide](https://docs.microsoft.com/azure/azure-functions/dotnet-isolated-process-guide)
