# Template — .NET 10 Azure Function App

A reusable solution template for .NET 10 Azure Functions (isolated worker model) with company-wide coding standards enforced at the solution level.

## Quick Start

### Install the template

```bash
dotnet new install ./Template
```

### Create a new project from the template

```bash
dotnet new contica-func -n MyIntegration
```

This scaffolds a solution named `MyIntegration` with:

```
MyIntegration/
├── .editorconfig          ← Company coding standards (enforced)
├── .gitignore
├── MyIntegration.slnx
└── src/
    └── MyIntegration.FunctionApp/
        ├── Functions/
        │   └── Time.cs    ← Sample HTTP trigger
        ├── Program.cs
        ├── host.json
        └── MyIntegration.FunctionApp.csproj
```

### Run locally

```bash
cd MyIntegration/src/MyIntegration.FunctionApp
func start
```

## What's Enforced

The `.editorconfig` at the solution root enforces these standards at **error** severity (build fails on violations):

### Naming Conventions

| Symbol                  | Convention       | Example                          |
|-------------------------|------------------|----------------------------------|
| Public types            | PascalCase       | `OrderService`, `CustomerModel`  |
| Public members          | PascalCase       | `GetOrder()`, `CustomerId`       |
| Private instance fields | `_camelCase`     | `_logger`, `_repository`         |
| Private static fields   | `s_camelCase`    | `s_instance`, `s_defaultValue`   |
| Local variables         | camelCase        | `itemCount`, `userId`            |
| Constants               | PascalCase       | `MaxRetryCount`, `DefaultTimeout`|
| Interfaces              | `I` prefix       | `IRepository`, `IService`        |
| Type parameters         | `T` prefix       | `TEntity`, `TRequest`            |
| Async methods           | `Async` suffix   | `GetDataAsync()`, `SaveAsync()`  |

### Formatting

- **Indentation**: 4 spaces (2 spaces for XML/JSON/YAML)
- **Braces**: Allman style (opening brace on its own line)
- **Namespaces**: File-scoped (`namespace X;`)
- **Using directives**: Outside namespace, System-first, alphabetically sorted
- **Max line length**: 120 characters (advisory)
- **Access modifiers**: Always explicit

### Code Quality

- Null-coalescing and null-propagation required
- Pattern matching preferred over `is`/`as` casts
- Collection expressions preferred (C# 12+)
- Braces required on all control flow
- `var` only when type is apparent from the right-hand side

## Overriding Rules

To override a rule for a specific project, add a `.editorconfig` file in that project's directory. More-specific files take precedence.

Example — relax async naming in a test project:

```ini
[*.cs]
dotnet_naming_rule.async_methods_must_end_with_async.severity = suggestion
```

## Uninstalling

```bash
dotnet new uninstall ./Template
```
