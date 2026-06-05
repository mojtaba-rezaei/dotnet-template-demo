using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service implementation for Service Bus message processing operations.
/// </summary>
public class ServiceBusMessageService : IServiceBusMessageService
{
    private readonly ILogger<ServiceBusMessageService> _logger;

    public ServiceBusMessageService(ILogger<ServiceBusMessageService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public Task<ServiceBusMessageResult> ProcessMessageAsync(string messageBody, string messageId)
    {
        _logger.LogDebug("Processing message: {MessageId}", messageId);

        var result = new ServiceBusMessageResult(
            MessageId: messageId,
            ProcessedAt: DateTime.UtcNow,
            ContentLength: messageBody.Length,
            Success: true);

        _logger.LogDebug("Message processing completed: {MessageId}", messageId);

        return Task.FromResult(result);
    }
}
