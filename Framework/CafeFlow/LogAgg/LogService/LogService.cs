using CafeFlow.Framework.LogAgg.Log.Contracts;
using Microsoft.Extensions.Logging;

namespace CafeFlow.Framework.LogAgg.LogService;

public class LogService(ILogger<LogService> logger) : ILogService
{

    public void LogVerbose(string message) =>  logger.LogTrace(message);

    public void LogDebug(string message) =>  logger.LogDebug(message);
 
    public void LogInformation(string message) =>  logger.LogInformation(message);

    public void LogWarning(string message) =>  logger.LogWarning(message);

    public void LogError(string message) =>  logger.LogError(message);

    public void LogFatal(string message) =>  logger.LogCritical(message);
}