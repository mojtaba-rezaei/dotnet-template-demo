using FluentAssertions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Functions;
using ProjectName.FunctionApp.Models;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="TimeFunction"/>.
/// </summary>
public class TimeFunctionTests
{
    private readonly ILogger<TimeFunction> _logger;
    private readonly ITimeService _timeService;
    private readonly TimeFunction _sut;

    public TimeFunctionTests()
    {
        _logger = Substitute.For<ILogger<TimeFunction>>();
        _timeService = Substitute.For<ITimeService>();
        _sut = new TimeFunction(_logger, _timeService);
    }

    [Fact]
    public async Task RunAsync_WhenCalled_ReturnsTimeResponse()
    {
        // Arrange
        var expectedResponse = new TimeResponse("2024-01-15T10:30:00.0000000Z", "UTC");
        _timeService.GetCurrentTimeAsync().Returns(Task.FromResult(expectedResponse));

        FunctionContext functionContext = Substitute.For<FunctionContext>();
        HttpRequestData request = CreateMockHttpRequestData(functionContext);

        // Act
        HttpResponseData response = await _sut.RunAsync(request);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        await _timeService.Received(1).GetCurrentTimeAsync();
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new TimeFunction(null!, _timeService);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }

    [Fact]
    public void Constructor_WithNullTimeService_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new TimeFunction(_logger, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("timeService");
    }

    private static HttpRequestData CreateMockHttpRequestData(FunctionContext context)
    {
        HttpRequestData request = Substitute.For<HttpRequestData>(context);
        HttpResponseData response = Substitute.For<HttpResponseData>(context);

        response.StatusCode = System.Net.HttpStatusCode.OK;
        response.Body.Returns(new MemoryStream());

        request.CreateResponse().Returns(response);

        return request;
    }
}
