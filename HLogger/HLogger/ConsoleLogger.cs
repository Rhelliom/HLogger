using System;
using System.Collections.Generic;

namespace HLogger
{
    /// <summary>
    /// A functional logger class that outputs messages to the console. Messages are colored according to level
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            Console.ForegroundColor = colors[level];
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private Dictionary<LogLevel, ConsoleColor> colors;

        public ConsoleLogger()
        {
            colors = new Dictionary<LogLevel, ConsoleColor>();
            colors.Add(LogLevel.Debug, ConsoleColor.Gray);
            colors.Add(LogLevel.Info, ConsoleColor.White);
            colors.Add(LogLevel.Warn, ConsoleColor.Yellow);
            colors.Add(LogLevel.Error, ConsoleColor.Red);
            colors.Add(LogLevel.Critical, ConsoleColor.DarkRed);
        }

        /// <summary>
        /// Set the color of text to be used for messages of a particular level
        /// </summary>
        /// <param name="level">The level of the message</param>
        /// <param name="color">The color of text to be used</param>
        public void SetColor(LogLevel level, ConsoleColor color)
        {
            colors[level] = color;
        }
    }
}
