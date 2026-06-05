using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Models;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Functions;

/// <summary>
/// HTTP triggered function that returns the current time.
/// </summary>
public class TimeFunction
{
    private readonly ILogger<TimeFunction> _logger;
    private readonly ITimeService _timeService;

    public TimeFunction(ILogger<TimeFunction> logger, ITimeService timeService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
    }

    [Function(nameof(TimeFunction))]
    public async Task<HttpResponseData> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "time")] HttpRequestData request)
    {
        _logger.LogInformation("Processing GetTime request");

        TimeResponse timeResponse = await _timeService.GetCurrentTimeAsync();

        HttpResponseData response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(timeResponse);

        return response;
    }
}
