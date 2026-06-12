using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProjectName.FunctionApp.Configuration;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Functions;

/// <summary>
/// Blob triggered function that processes uploaded blobs.
/// </summary>
public class BlobProcessorFunction
{
    private readonly ILogger<BlobProcessorFunction> _logger;
    private readonly IBlobProcessorService _blobProcessorService;

    public BlobProcessorFunction(ILogger<BlobProcessorFunction> logger, IBlobProcessorService blobProcessorService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _blobProcessorService = blobProcessorService ?? throw new ArgumentNullException(nameof(blobProcessorService));
    }

    [Function(nameof(BlobProcessorFunction))]
    public async Task RunAsync(
        [BlobTrigger($"{Constants.BLOB_CONTAINER_NAME}/{{name}}", Connection = "AzureWebJobsStorage")] Stream stream,
        string name)
    {
        _logger.LogInformation("Processing blob: {BlobName}, Size: {Size} bytes", name, stream.Length);

        await _blobProcessorService.ProcessBlobAsync(name, stream);

        _logger.LogInformation("Completed processing blob: {BlobName}", name);
    }
}
