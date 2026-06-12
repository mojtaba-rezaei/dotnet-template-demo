namespace ProjectName.FunctionApp.Configuration;

/// <summary>
/// Application-wide constants following UPPER_SNAKE_CASE naming convention.
/// </summary>
public static class Constants
{
    /// <summary>
    /// Maximum retry count for transient failure handling.
    /// </summary>
    public const int MAX_RETRY_COUNT = 3;

    /// <summary>
    /// Default timeout in seconds for external service calls.
    /// </summary>
    public const int DEFAULT_TIMEOUT_SECONDS = 30;

#if (HttpTrigger)
    /// <summary>
    /// Default time zone identifier used throughout the application.
    /// </summary>
    public const string DEFAULT_TIME_ZONE = "UTC";
#endif

#if (BlobTrigger)
    /// <summary>
    /// Blob storage container name for processing.
    /// </summary>
    public const string BLOB_CONTAINER_NAME = "processing";
#endif

#if (ServiceBusTrigger)
    /// <summary>
    /// Service Bus queue name for messages.
    /// </summary>
    public const string SERVICE_BUS_QUEUE_NAME = "messages";
#endif

#if (TimerTrigger)
    /// <summary>
    /// Timer trigger CRON expression (every 5 minutes).
    /// </summary>
    public const string TIMER_CRON_EXPRESSION = "0 */5 * * * *";
#endif

#if (QueueTrigger)
    /// <summary>
    /// Storage queue name for queue trigger.
    /// </summary>
    public const string STORAGE_QUEUE_NAME = "items";
#endif
}
