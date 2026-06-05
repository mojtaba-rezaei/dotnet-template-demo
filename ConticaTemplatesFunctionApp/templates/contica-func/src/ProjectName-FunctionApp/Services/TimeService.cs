using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Configuration;
using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service implementation for time-related operations.
/// </summary>
public class TimeService : ITimeService
{
    private readonly ILogger<TimeService> _logger;

    public TimeService(ILogger<TimeService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public Task<TimeResponse> GetCurrentTimeAsync()
    {
        _logger.LogDebug("Getting current time");

        var response = new TimeResponse(
            UtcNow: DateTime.UtcNow.ToString("o"),
            TimeZone: Constants.DEFAULT_TIME_ZONE);

        return Task.FromResult(response);
    }
}
