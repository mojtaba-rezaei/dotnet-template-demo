using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service interface for scheduled task operations.
/// </summary>
public interface IScheduledTaskService
{
    /// <summary>
    /// Executes the scheduled task.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the execution result.</returns>
    public Task<ScheduledTaskResult> ExecuteAsync();
}
