using System;
using System.IO;

namespace HLogger
{
    /// <summary>
    /// A functional logger class that writes log entries to a file
    /// </summary>
    public class FileLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            File.AppendAllText(file, message + Environment.NewLine);
        }

        private string file;

        public FileLogger(string path, bool overwrite = true)
        {
            file = path;
            string dir = Directory.GetParent(path).Name;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(path) && overwrite)
            {
                File.Delete(path);
            }
        }
    }
}
