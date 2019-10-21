
namespace HLogger
{
    public interface ILogger
    {
        void Log(string message, LogLevel level);
    }

    public enum LogLevel { Debug, Info, Warn, Error, Critical }
}
