using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Configuration;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Functions;

/// <summary>
/// Queue triggered function that processes storage queue messages.
/// </summary>
public class QueueMessageFunction
{
    private readonly ILogger<QueueMessageFunction> _logger;
    private readonly IQueueMessageService _queueMessageService;

    public QueueMessageFunction(ILogger<QueueMessageFunction> logger, IQueueMessageService queueMessageService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _queueMessageService = queueMessageService ?? throw new ArgumentNullException(nameof(queueMessageService));
    }

    [Function(nameof(QueueMessageFunction))]
    public async Task RunAsync(
        [QueueTrigger(Constants.STORAGE_QUEUE_NAME, Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation("Processing queue message");

        await _queueMessageService.ProcessMessageAsync(message);

        _logger.LogInformation("Completed processing queue message");
    }
}
