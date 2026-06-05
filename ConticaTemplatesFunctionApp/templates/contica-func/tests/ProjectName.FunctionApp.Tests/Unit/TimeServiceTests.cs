using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Configuration;
using ProjectName.FunctionApp.Models;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="TimeService"/>.
/// </summary>
public class TimeServiceTests
{
    private readonly ILogger<TimeService> _logger;
    private readonly TimeService _sut;

    public TimeServiceTests()
    {
        _logger = Substitute.For<ILogger<TimeService>>();
        _sut = new TimeService(_logger);
    }

    [Fact]
    public async Task GetCurrentTimeAsync_WhenCalled_ReturnsTimeResponse()
    {
        // Arrange
        DateTime beforeCall = DateTime.UtcNow;

        // Act
        TimeResponse result = await _sut.GetCurrentTimeAsync();

        // Assert
        DateTime afterCall = DateTime.UtcNow;

        result.Should().NotBeNull();
        result.TimeZone.Should().Be(Constants.DEFAULT_TIME_ZONE);

        DateTime parsedTime = DateTime.Parse(result.UtcNow);
        parsedTime.Should().BeOnOrAfter(beforeCall);
        parsedTime.Should().BeOnOrBefore(afterCall);
    }

    [Fact]
    public async Task GetCurrentTimeAsync_WhenCalled_ReturnsIso8601FormattedTime()
    {
        // Act
        TimeResponse result = await _sut.GetCurrentTimeAsync();

        // Assert
        result.UtcNow.Should().Contain("T");
        result.UtcNow.Should().EndWith("Z");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new TimeService(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }
}
