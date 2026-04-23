using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Template.FunctionApp.Functions;

public class Time
{
    private readonly ILogger<Time> _logger;

    public Time(ILogger<Time> logger)
    {
        _logger = logger;
    }

    [Function(nameof(Time))]
    public IResult Run([HttpTrigger(AuthorizationLevel.Function, "get")]
    HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return Results.Ok(DateTime.UtcNow.ToString("o"));
    }
}
