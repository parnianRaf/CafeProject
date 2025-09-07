namespace CafeFlow.Framework.LogAgg.Log.Contracts;

public interface ILogService
{
    void LogVerbose(string message);
    void LogDebug(string message);
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
    void LogFatal(string message);
}