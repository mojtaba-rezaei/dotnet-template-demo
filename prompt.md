# Contica Azure Function App — dotnet new Template Package Generator

Generate a **publishable `dotnet new` template NuGet package** for a .NET 10 isolated-process Azure Function App following Contica standards.

---

## Package Identity

- **NuGet PackageId**: `contica-templates-func`
- **Template shortName**: `contica-func`
- **Template sourceName**: `ProjectName` (replaced by `-n` value at instantiation)

## Package Structure

```
ConticaTemplatesFunctionApp/
├── ConticaTemplatesFunctionApp.csproj   # PackageType=Template, packs templates/ as content
└── templates/
    └── contica-func/
        ├── .template.config/template.json # Don't generate when running dotnet new
        ├── src/
        │   ├── .editorconfig
        │   ├── ProjectName.slnx
        │   └── ProjectName-FunctionApp/
        │       ├── ProjectName-FunctionApp.csproj
        │       ├── Functions/
        │       ├── Services/
        │       ├── Models/
        │       ├── Mappings/           ← .gitkeep
        │       ├── Configuration/
        │       ├── Middleware/          ← .gitkeep
        │       ├── Program.cs
        │       ├── host.json
        │       └── local.settings.json
        ├── tests/
        │   └── ProjectName.FunctionApp.Tests/
        │       ├── ProjectName.FunctionApp.Tests.csproj  (xUnit + NSubstitute)
        │       ├── Unit/
        └       └── Integration/        ← .gitkeep
```

---

## Trigger Selection (template.json boolean parameters)

Each trigger = one thin Function class + service interface + service impl + response model + unit test. Use `#if (ParamName)` / `#endif` in Program.cs for conditional DI. Use `sources.modifiers` with `condition` + `exclude` in template.json for conditional file inclusion.

**If no trigger is selected** → empty scaffold only (.editorconfig and .slnx).

- [x] **HttpTrigger** (default: true) — `GET /api/time` → `{ "utcNow": "...", "timeZone": "UTC" }`
- [ ] BlobTrigger (default: false)
- [ ] ServiceBusTrigger (default: false)
- [ ] TimerTrigger (default: false)
- [ ] QueueTrigger (default: false)

---

## Coding Standards (enforced via src/.editorconfig at error severity)

### Naming

| Symbol | Convention | Example |
|---|---|---|
| Public types | PascalCase | `OrderService`, `CustomerModel` |
| Public members | PascalCase | `GetOrder()`, `CustomerId` |
| Private instance fields | `_camelCase` | `_logger`, `_repository` |
| Private static fields | `s_camelCase` | `s_instance`, `s_defaultValue` |
| Local variables | camelCase | `itemCount`, `userId` |
| Constants | UPPER_SNAKE_CASE | `MAX_RETRY_COUNT`, `DEFAULT_TIMEOUT` |
| Interfaces | `I` prefix | `IRepository`, `IService` |
| Type parameters | `T` prefix | `TEntity`, `TRequest` |
| Async methods | `Async` suffix | `GetDataAsync()`, `SaveAsync()` |

### Formatting

- 4 spaces (2 for XML/JSON/YAML)
- Allman braces
- File-scoped namespaces
- Usings outside namespace, System-first, alphabetically sorted
- Max line length 120 (advisory)
- Access modifiers always explicit
- Error for not used using.

### Code Quality

- Null-coalescing and null-propagation required
- Pattern matching over `is`/`as` casts
- Collection expressions preferred (C# 12+)
- Braces on all control flow
- `var` only when type is apparent from the RHS

---

## Architecture Rules

1. Functions are **thin** — receive request → call service → return response. Zero logic in triggers.
2. **No MVC** — no controllers, no `IActionResult`. Use `HttpRequestData` / `HttpResponseData` (isolated model).
3. Services registered in `Program.cs` via DI.
4. Models use `record` types where possible.
5. Constants live in `Configuration/Constants.cs` with UPPER_SNAKE_CASE.
6. Use `ILogger<T>` via constructor injection.
7. Sync methods must NOT have `Async` suffix. Only actually async methods get it.

---

## Output

Emit every file with its **full relative path from `ConticaTemplatesFunctionApp/`** as a heading, followed by complete content in a fenced code block. No placeholders, no `// TODO`, no truncation.
