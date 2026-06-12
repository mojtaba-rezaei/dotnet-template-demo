using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service interface for blob processing operations.
/// </summary>
public interface IBlobProcessorService
{
    /// <summary>
    /// Processes a blob from storage.
    /// </summary>
    /// <param name="blobName">The name of the blob.</param>
    /// <param name="stream">The blob content stream.</param>
    /// <returns>A task that represents the asynchronous operation, containing the processing result.</returns>
    public Task<BlobProcessingResult> ProcessBlobAsync(string blobName, Stream stream);
}
