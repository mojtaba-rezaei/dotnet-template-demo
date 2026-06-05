using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service implementation for scheduled task operations.
/// </summary>
public class ScheduledTaskService : IScheduledTaskService
{
    private readonly ILogger<ScheduledTaskService> _logger;

    public ScheduledTaskService(ILogger<ScheduledTaskService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public Task<ScheduledTaskResult> ExecuteAsync()
    {
        _logger.LogDebug("Executing scheduled task");

        var result = new ScheduledTaskResult(
            ExecutedAt: DateTime.UtcNow,
            TaskName: "ScheduledTask",
            Success: true);

        _logger.LogDebug("Scheduled task execution completed");

        return Task.FromResult(result);
    }
}
