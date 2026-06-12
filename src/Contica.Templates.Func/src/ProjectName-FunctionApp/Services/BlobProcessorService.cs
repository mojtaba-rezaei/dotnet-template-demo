using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service implementation for blob processing operations.
/// </summary>
public class BlobProcessorService : IBlobProcessorService
{
    private readonly ILogger<BlobProcessorService> _logger;

    public BlobProcessorService(ILogger<BlobProcessorService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public async Task<BlobProcessingResult> ProcessBlobAsync(string blobName, Stream stream)
    {
        _logger.LogDebug("Starting blob processing for: {BlobName}", blobName);

        using var reader = new StreamReader(stream);
        string content = await reader.ReadToEndAsync();

        var result = new BlobProcessingResult(
            BlobName: blobName,
            ProcessedAt: DateTime.UtcNow,
            BytesProcessed: stream.Length,
            Success: true);

        _logger.LogDebug("Blob processing completed for: {BlobName}", blobName);

        return result;
    }
}
