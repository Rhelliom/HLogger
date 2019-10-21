
using System.Collections.Generic;

namespace HLogger
{
    /// <summary>
    /// An intermediary logger class that forwards messages to multiple internal loggers
    /// </summary>
    public class MultiLogger : ILogger
    {
        private List<ILogger> loggers;

        /// <summary>
        /// The internal loggers messages will be forwarded to
        /// </summary>
        public IReadOnlyList<ILogger> Loggers { get { return loggers.AsReadOnly();} }

        public MultiLogger() : this (new List<ILogger>()) { }

        public MultiLogger(List<ILogger> loggers) { this.loggers = loggers; }

        /// <summary>
        /// Adds a logger object to the list of internal loggers
        /// </summary>
        /// <param name="logger">The ILogger object to be added</param>
        public void Add(ILogger logger)
        {
            loggers.Add(logger);
        }

        /// <summary>
        /// Removes a logger object from the list of internal loggers
        /// </summary>
        /// <param name="logger">The ILogger object to be removed</param>
        public void Remove(ILogger logger)
        {
            loggers.Remove(logger);
        }

        public void Log(string message, LogLevel level)
        {
            foreach(ILogger l in loggers)
            {
                l.Log(message, level);
            }
        }
    }
}
