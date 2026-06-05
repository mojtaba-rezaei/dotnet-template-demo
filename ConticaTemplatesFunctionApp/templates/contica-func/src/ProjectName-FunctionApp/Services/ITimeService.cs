using ProjectName.FunctionApp.Models;

namespace ProjectName.FunctionApp.Services;

/// <summary>
/// Service interface for time-related operations.
/// </summary>
public interface ITimeService
{
    /// <summary>
    /// Gets the current time information.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the time response.</returns>
    Task<TimeResponse> GetCurrentTimeAsync();
}
