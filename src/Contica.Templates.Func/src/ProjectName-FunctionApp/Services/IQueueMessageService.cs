using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service interface for queue message processing operations.
/// </summary>
public interface IQueueMessageService
{
    /// <summary>
    /// Processes a storage queue message.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <returns>A task that represents the asynchronous operation, containing the processing result.</returns>
    Task<QueueMessageResult> ProcessMessageAsync(string message);
}
