using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Configuration;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Functions;

/// <summary>
/// Service Bus triggered function that processes queue messages.
/// </summary>
public class ServiceBusMessageFunction
{
    private readonly ILogger<ServiceBusMessageFunction> _logger;
    private readonly IServiceBusMessageService _serviceBusMessageService;

    public ServiceBusMessageFunction(
        ILogger<ServiceBusMessageFunction> logger,
        IServiceBusMessageService serviceBusMessageService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _serviceBusMessageService = serviceBusMessageService ?? throw new ArgumentNullException(nameof(serviceBusMessageService));
    }

    [Function(nameof(ServiceBusMessageFunction))]
    public async Task RunAsync(
        [ServiceBusTrigger(Constants.SERVICE_BUS_QUEUE_NAME, Connection = "ServiceBusConnection")] ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Processing Service Bus message: {MessageId}", message.MessageId);

        await _serviceBusMessageService.ProcessMessageAsync(message.Body.ToString(), message.MessageId);

        await messageActions.CompleteMessageAsync(message);

        _logger.LogInformation("Completed processing Service Bus message: {MessageId}", message.MessageId);
    }
}
