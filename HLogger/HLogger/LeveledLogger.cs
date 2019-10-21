
namespace HLogger
{
    /// <summary>
    /// An intermediary logger class that filters out messages with too low a priority before sending them to the internal logger
    /// </summary>
    public class LeveledLogger : ILogger
    {
        /// <summary>
        /// The lowest level of message that will actually be recorded
        /// </summary>
        public LogLevel Threshold { get; set; }
        /// <summary>
        /// The internal logger that accepted messages are forwarded to
        /// </summary>
        public ILogger Internal { get; }

        public LeveledLogger(ILogger logger, LogLevel minLevel = LogLevel.Info)
        {
            Internal = logger;
            Threshold = minLevel;
        }

        public void Log(string message, LogLevel level)
        {
            if(level >= Threshold)
            {
                Internal.Log(message, level);
            }
        }
    }
}
