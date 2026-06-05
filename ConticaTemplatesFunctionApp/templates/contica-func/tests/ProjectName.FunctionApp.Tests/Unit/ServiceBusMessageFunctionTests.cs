using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProjectName.FunctionApp.Functions;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ServiceBusMessageFunction"/>.
/// </summary>
public class ServiceBusMessageFunctionTests
{
    private readonly ILogger<ServiceBusMessageFunction> _logger;
    private readonly IServiceBusMessageService _serviceBusMessageService;
    private readonly ServiceBusMessageFunction _sut;

    public ServiceBusMessageFunctionTests()
    {
        _logger = Substitute.For<ILogger<ServiceBusMessageFunction>>();
        _serviceBusMessageService = Substitute.For<IServiceBusMessageService>();
        _sut = new ServiceBusMessageFunction(_logger, _serviceBusMessageService);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new ServiceBusMessageFunction(null!, _serviceBusMessageService);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("logger");
    }

    [Fact]
    public void Constructor_WithNullService_ThrowsArgumentNullException()
    {
        // Arrange & Act
        Action act = () => new ServiceBusMessageFunction(_logger, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("serviceBusMessageService");
    }
}
