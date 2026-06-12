namespace ProjectName.FunctionApp.Models;

/// <summary>
/// Result model for Service Bus message processing operations.
/// </summary>
/// <param name="MessageId">The identifier of the processed message.</param>
/// <param name="ProcessedAt">The UTC timestamp when processing completed.</param>
/// <param name="ContentLength">The length of the message content.</param>
/// <param name="Success">Indicates whether processing was successful.</param>
public record ServiceBusMessageResult(string MessageId, DateTime ProcessedAt, int ContentLength, bool Success);
