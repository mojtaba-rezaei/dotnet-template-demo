using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Models;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="BlobProcessorService"/>.
/// </summary>
public class BlobProcessorServiceTests
{
    private readonly ILogger<BlobProcessorService> _logger;
    private readonly BlobProcessorService _sut;

    public BlobProcessorServiceTests()
    {
        _logger = Substitute.For<ILogger<BlobProcessorService>>();
        _sut = new BlobProcessorService(_logger);
    }

    [Fact]
    public async Task ProcessBlobAsync_WhenCalled_ReturnsSuccessfulResult()
    {
        // Arrange
        string blobName = "test-blob.txt";
        string content = "Test blob content";
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));

        // Act
        BlobProcessingResult result = await _sut.ProcessBlobAsync(blobName, stream);

        // Assert
        result.Should().NotBeNull();
        result.BlobName.Should().Be(blobName);
        result.Success.Should().BeTrue();
        result.BytesProcessed.Should().Be(content.Length);
    }

    [Fact]
    public async Task ProcessBlobAsync_WhenCalled_SetsProcessedAtToCurrentTime()
    {
        // Arrange
        string blobName = "test-blob.txt";
        using var stream = new MemoryStream("content"u8.ToArray());
        DateTime beforeCall = DateTime.UtcNow;

        // Act
        BlobProcessingResult result = await _sut.ProcessBlobAsync(blobName, stream);

        // Assert
        DateTime afterCall = DateTime.UtcNow;
        result.ProcessedAt.Should().BeOnOrAfter(beforeCall);
        result.ProcessedAt.Should().BeOnOrBefore(afterCall);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new BlobProcessorService(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }
}
