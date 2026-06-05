using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Models;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ServiceBusMessageService"/>.
/// </summary>
public class ServiceBusMessageServiceTests
{
    private readonly ILogger<ServiceBusMessageService> _logger;
    private readonly ServiceBusMessageService _sut;

    public ServiceBusMessageServiceTests()
    {
        _logger = Substitute.For<ILogger<ServiceBusMessageService>>();
        _sut = new ServiceBusMessageService(_logger);
    }

    [Fact]
    public async Task ProcessMessageAsync_WhenCalled_ReturnsSuccessfulResult()
    {
        // Arrange
        string messageBody = "Test message content";
        string messageId = "msg-001";

        // Act
        ServiceBusMessageResult result = await _sut.ProcessMessageAsync(messageBody, messageId);

        // Assert
        result.Should().NotBeNull();
        result.MessageId.Should().Be(messageId);
        result.ContentLength.Should().Be(messageBody.Length);
        result.Success.Should().BeTrue();
    }

    [Fact]
    public async Task ProcessMessageAsync_WhenCalled_SetsProcessedAtToCurrentTime()
    {
        // Arrange
        DateTime beforeCall = DateTime.UtcNow;

        // Act
        ServiceBusMessageResult result = await _sut.ProcessMessageAsync("content", "msg-001");

        // Assert
        DateTime afterCall = DateTime.UtcNow;
        result.ProcessedAt.Should().BeOnOrAfter(beforeCall);
        result.ProcessedAt.Should().BeOnOrBefore(afterCall);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new ServiceBusMessageService(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }
}
