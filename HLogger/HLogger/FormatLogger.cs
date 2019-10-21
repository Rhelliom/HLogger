using System;

namespace HLogger
{
    /// <summary>
    /// An intermediary logger class that applies timestamp and sender formatting to messages before sending them to the internal logger
    /// Recccomended for use as the highest-level logger for access to the convenience methods Info(string), Debug(string), Error(string), etc.
    /// </summary>
    public class FormatLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            Internal.Log($"[{DateTime.Now}][{Sender}][{level}] {message}", level);
        }

        /// <summary>
        /// The internal logger that messages are forwarded to
        /// </summary>
        public ILogger Internal { get; }
        
        /// <summary>
        /// The label used by this FormatLogger
        /// </summary>
        public string Sender { get; }

        public FormatLogger(ILogger logger, string senderName)
        {
            Sender = senderName;
            Internal = logger;
        }

        /// <summary>
        /// Logs a message with the Info LogLevel
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            Log(message, LogLevel.Info);
        }

        /// <summary>
        /// Logs a message with the Debug LogLevel
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            Log(message, LogLevel.Debug);
        }

        /// <summary>
        /// Logs a message with the Warn LogLevel
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            Log(message, LogLevel.Warn);
        }

        /// <summary>
        /// Logs a message with the Error LogLevel
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            Log(message, LogLevel.Error);
        }

        /// <summary>
        /// Logs a message with the Critical LogLevel
        /// </summary>
        /// <param name="message"></param>
        public void Critical(string message)
        {
            Log(message, LogLevel.Critical);
        }

        /// <summary>
        /// Creates a new FormatLogger using the same internal logger as this one.
        /// </summary>
        /// <param name="sender">The label to be used by the new FormatLogger</param>
        /// <returns></returns>
        public FormatLogger Branch(string sender)
        {
            return new FormatLogger(Internal, sender);
        }
    }
}
