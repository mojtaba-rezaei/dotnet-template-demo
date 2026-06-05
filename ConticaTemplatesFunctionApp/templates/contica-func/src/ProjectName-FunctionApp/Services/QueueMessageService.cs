using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service implementation for queue message processing operations.
/// </summary>
public class QueueMessageService : IQueueMessageService
{
    private readonly ILogger<QueueMessageService> _logger;

    public QueueMessageService(ILogger<QueueMessageService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public Task<QueueMessageResult> ProcessMessageAsync(string message)
    {
        _logger.LogDebug("Processing queue message");

        var result = new QueueMessageResult(
            ProcessedAt: DateTime.UtcNow,
            ContentLength: message.Length,
            Success: true);

        _logger.LogDebug("Queue message processing completed");

        return Task.FromResult(result);
    }
}
