using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Configuration;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Functions;

/// <summary>
/// Timer triggered function that executes scheduled tasks.
/// </summary>
public class ScheduledTaskFunction
{
    private readonly ILogger<ScheduledTaskFunction> _logger;
    private readonly IScheduledTaskService _scheduledTaskService;

    public ScheduledTaskFunction(ILogger<ScheduledTaskFunction> logger, IScheduledTaskService scheduledTaskService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _scheduledTaskService = scheduledTaskService ?? throw new ArgumentNullException(nameof(scheduledTaskService));
    }

    [Function(nameof(ScheduledTaskFunction))]
    public async Task RunAsync(
        [TimerTrigger(Constants.TIMER_CRON_EXPRESSION)] TimerInfo timerInfo)
    {
        _logger.LogInformation("Executing scheduled task at: {UtcNow}", DateTime.UtcNow);

        if (timerInfo.IsPastDue)
        {
            _logger.LogWarning("Timer trigger is running late");
        }

        await _scheduledTaskService.ExecuteAsync();

        _logger.LogInformation("Scheduled task execution completed");
    }
}
