namespace ProjectName.FunctionApp.Models;

/// <summary>
/// Result model for scheduled task execution.
/// </summary>
/// <param name="ExecutedAt">The UTC timestamp when the task was executed.</param>
/// <param name="TaskName">The name of the executed task.</param>
/// <param name="Success">Indicates whether execution was successful.</param>
public record ScheduledTaskResult(DateTime ExecutedAt, string TaskName, bool Success);
