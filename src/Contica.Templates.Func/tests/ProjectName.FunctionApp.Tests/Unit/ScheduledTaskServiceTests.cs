using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Models;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ScheduledTaskService"/>.
/// </summary>
public class ScheduledTaskServiceTests
{
    private readonly ILogger<ScheduledTaskService> _logger;
    private readonly ScheduledTaskService _sut;

    public ScheduledTaskServiceTests()
    {
        _logger = Substitute.For<ILogger<ScheduledTaskService>>();
        _sut = new ScheduledTaskService(_logger);
    }

    [Fact]
    public async Task ExecuteAsync_WhenCalled_ReturnsSuccessfulResult()
    {
        // Act
        ScheduledTaskResult result = await _sut.ExecuteAsync();

        // Assert
        result.Should().NotBeNull();
        result.TaskName.Should().Be("ScheduledTask");
        result.Success.Should().BeTrue();
    }

    [Fact]
    public async Task ExecuteAsync_WhenCalled_SetsExecutedAtToCurrentTime()
    {
        // Arrange
        DateTime beforeCall = DateTime.UtcNow;

        // Act
        ScheduledTaskResult result = await _sut.ExecuteAsync();

        // Assert
        DateTime afterCall = DateTime.UtcNow;
        result.ExecutedAt.Should().BeOnOrAfter(beforeCall);
        result.ExecutedAt.Should().BeOnOrBefore(afterCall);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new ScheduledTaskService(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }
}
