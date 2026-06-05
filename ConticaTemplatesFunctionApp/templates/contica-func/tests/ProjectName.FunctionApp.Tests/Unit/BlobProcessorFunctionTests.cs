using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Functions;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="BlobProcessorFunction"/>.
/// </summary>
public class BlobProcessorFunctionTests
{
    private readonly ILogger<BlobProcessorFunction> _logger;
    private readonly IBlobProcessorService _blobProcessorService;
    private readonly BlobProcessorFunction _sut;

    public BlobProcessorFunctionTests()
    {
        _logger = Substitute.For<ILogger<BlobProcessorFunction>>();
        _blobProcessorService = Substitute.For<IBlobProcessorService>();
        _sut = new BlobProcessorFunction(_logger, _blobProcessorService);
    }

    [Fact]
    public async Task RunAsync_WhenCalled_ProcessesBlob()
    {
        // Arrange
        string blobName = "test-blob.txt";
        using var stream = new MemoryStream("Test content"u8.ToArray());

        // Act
        await _sut.RunAsync(stream, blobName);

        // Assert
        await _blobProcessorService.Received(1).ProcessBlobAsync(blobName, stream);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new BlobProcessorFunction(null!, _blobProcessorService);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }

    [Fact]
    public void Constructor_WithNullService_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new BlobProcessorFunction(_logger, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("blobProcessorService");
    }
}
