using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Functions;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="QueueMessageFunction"/>.
/// </summary>
public class QueueMessageFunctionTests
{
    private readonly ILogger<QueueMessageFunction> _logger;
    private readonly IQueueMessageService _queueMessageService;
    private readonly QueueMessageFunction _sut;

    public QueueMessageFunctionTests()
    {
        _logger = Substitute.For<ILogger<QueueMessageFunction>>();
        _queueMessageService = Substitute.For<IQueueMessageService>();
        _sut = new QueueMessageFunction(_logger, _queueMessageService);
    }

    [Fact]
    public async Task RunAsync_WhenCalled_ProcessesMessage()
    {
        // Arrange
        string message = "Test queue message";

        // Act
        await _sut.RunAsync(message);

        // Assert
        await _queueMessageService.Received(1).ProcessMessageAsync(message);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new QueueMessageFunction(null!, _queueMessageService);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }

    [Fact]
    public void Constructor_WithNullService_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new QueueMessageFunction(_logger, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("queueMessageService");
    }
}
