# Contica .NET Templates

A collection of `dotnet new` templates for creating .NET applications following Contica AB standards.

## Available Templates

| Template | Package ID | Short Name | Description |
|----------|------------|------------|-------------|
| [Azure Function App](src/Contica.Templates.Func/) | `contica.templates.func` | `contica-func` | .NET 10 isolated-process Azure Functions |
| *Web API* | *coming soon* | *contica-api* | *ASP.NET Core Web API* |

## Quick Install

```bash
# Install all templates
dotnet new install contica.templates.func

# List installed Contica templates
dotnet new list contica
```

## Repository Structure

```
contica-templates/
├── README.md                           # This file
└── src/
    ├── Contica.Templates.Func/         # Azure Function App template
    │   ├── Contica.Templates.Func.csproj
    │   ├── README.md                   # NuGet package documentation
    │   ├── .template.config/           # Template engine config
    │   ├── src/                        # Template source files
    │   └── tests/                      # Template test files
    ├── Contica.Templates.Api/          # (future) Web API template
    └── Contica.Templates.Worker/       # (future) Worker Service template
```

## Development

### Prerequisites

- .NET 10 SDK
- Visual Studio 2022+ or VS Code

### Building a Template Package

```bash
cd src/Contica.Templates.Func
dotnet pack
```

### Testing Locally

```bash
# Install from local nupkg
dotnet new install ./bin/Release/contica.templates.func.1.0.0.nupkg

# Create a test project
dotnet new contica-func -n TestApp -o ./test-output

# Uninstall when done
dotnet new uninstall contica.templates.func
```

### Publishing to NuGet

```bash
dotnet nuget push ./bin/Release/contica.templates.func.1.0.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

## Standards

All templates follow Contica standards:

- **Clean architecture** - Separation of concerns with thin entry points
- **Dependency injection** - Extension methods for service registration
- **Unit testing** - xUnit + NSubstitute + FluentAssertions
- **Code style** - EditorConfig with consistent formatting rules
- **Modern .NET** - Latest LTS or STS versions

## Contributing

1. Fork the repository
2. Create a feature branch
3. Follow existing template patterns
4. Add/update tests
5. Submit a pull request

## License

This project is licensed under the [MIT License](LICENSE).

