using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Functions;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ScheduledTaskFunction"/>.
/// </summary>
public class ScheduledTaskFunctionTests
{
    private readonly ILogger<ScheduledTaskFunction> _logger;
    private readonly IScheduledTaskService _scheduledTaskService;
    private readonly ScheduledTaskFunction _sut;

    public ScheduledTaskFunctionTests()
    {
        _logger = Substitute.For<ILogger<ScheduledTaskFunction>>();
        _scheduledTaskService = Substitute.For<IScheduledTaskService>();
        _sut = new ScheduledTaskFunction(_logger, _scheduledTaskService);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new ScheduledTaskFunction(null!, _scheduledTaskService);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }

    [Fact]
    public void Constructor_WithNullService_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new ScheduledTaskFunction(_logger, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("scheduledTaskService");
    }
}
