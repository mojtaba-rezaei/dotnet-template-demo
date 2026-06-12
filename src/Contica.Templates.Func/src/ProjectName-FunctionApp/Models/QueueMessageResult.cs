namespace ProjectName.FunctionApp.Models;

/// <summary>
/// Result model for queue message processing operations.
/// </summary>
/// <param name="ProcessedAt">The UTC timestamp when processing completed.</param>
/// <param name="ContentLength">The length of the message content.</param>
/// <param name="Success">Indicates whether processing was successful.</param>
public record QueueMessageResult(DateTime ProcessedAt, int ContentLength, bool Success);
