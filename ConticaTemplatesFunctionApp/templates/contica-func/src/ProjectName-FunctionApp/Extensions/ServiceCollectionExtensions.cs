using Microsoft.Extensions.DependencyInjection;
using ProjectName.FunctionApp.Services;

namespace ProjectName.FunctionApp.Extensions;

/// <summary>
/// Extension methods for configuring application services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds application services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
#if (HttpTrigger)
        services.AddScoped<ITimeService, TimeService>();
#endif
#if (BlobTrigger)
        services.AddScoped<IBlobProcessorService, BlobProcessorService>();
#endif
#if (ServiceBusTrigger)
        services.AddScoped<IServiceBusMessageService, ServiceBusMessageService>();
#endif
#if (TimerTrigger)
        services.AddScoped<IScheduledTaskService, ScheduledTaskService>();
#endif
#if (QueueTrigger)
        services.AddScoped<IQueueMessageService, QueueMessageService>();
#endif

        return services;
    }
}
