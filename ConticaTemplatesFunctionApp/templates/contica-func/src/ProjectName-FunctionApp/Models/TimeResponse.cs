namespace ProjectName.FunctionApp.Models;

/// <summary>
/// Response model containing current time information.
/// </summary>
/// <param name="UtcNow">The current UTC time in ISO 8601 format.</param>
/// <param name="TimeZone">The time zone identifier.</param>
public record TimeResponse(string UtcNow, string TimeZone);
