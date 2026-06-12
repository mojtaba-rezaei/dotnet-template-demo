namespace ProjectName.FunctionApp.Models;

/// <summary>
/// Result model for blob processing operations.
/// </summary>
/// <param name="BlobName">The name of the processed blob.</param>
/// <param name="ProcessedAt">The UTC timestamp when processing completed.</param>
/// <param name="BytesProcessed">The number of bytes processed.</param>
/// <param name="Success">Indicates whether processing was successful.</param>
public record BlobProcessingResult(string BlobName, DateTime ProcessedAt, long BytesProcessed, bool Success);
