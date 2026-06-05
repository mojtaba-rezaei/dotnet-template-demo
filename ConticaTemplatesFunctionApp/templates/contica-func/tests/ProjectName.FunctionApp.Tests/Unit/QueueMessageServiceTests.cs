using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Models;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="QueueMessageService"/>.
/// </summary>
public class QueueMessageServiceTests
{
    private readonly ILogger<QueueMessageService> _logger;
    private readonly QueueMessageService _sut;

    public QueueMessageServiceTests()
    {
        _logger = Substitute.For<ILogger<QueueMessageService>>();
        _sut = new QueueMessageService(_logger);
    }

    [Fact]
    public async Task ProcessMessageAsync_WhenCalled_ReturnsSuccessfulResult()
    {
        // Arrange
        string message = "Test message content";

        // Act
        QueueMessageResult result = await _sut.ProcessMessageAsync(message);

        // Assert
        result.Should().NotBeNull();
        result.ContentLength.Should().Be(message.Length);
        result.Success.Should().BeTrue();
    }

    [Fact]
    public async Task ProcessMessageAsync_WhenCalled_SetsProcessedAtToCurrentTime()
    {
        // Arrange
        DateTime beforeCall = DateTime.UtcNow;

        // Act
        QueueMessageResult result = await _sut.ProcessMessageAsync("content");

        // Assert
        DateTime afterCall = DateTime.UtcNow;
        result.ProcessedAt.Should().BeOnOrAfter(beforeCall);
        result.ProcessedAt.Should().BeOnOrBefore(afterCall);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new QueueMessageService(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }
}
