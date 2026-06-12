using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service interface for Service Bus message processing operations.
/// </summary>
public interface IServiceBusMessageService
{
    /// <summary>
    /// Processes a Service Bus message.
    /// </summary>
    /// <param name="messageBody">The message body content.</param>
    /// <param name="messageId">The message identifier.</param>
    /// <returns>A task that represents the asynchronous operation, containing the processing result.</returns>
    public Task<ServiceBusMessageResult> ProcessMessageAsync(string messageBody, string messageId);
}
