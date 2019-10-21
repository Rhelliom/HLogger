# HLogger
A simple and extensible logging system

The HLogger system is built around a simple interface, ILogger. It comes equipped with two "proper" logger classes: FileLogger and ConsoleLogger, as well as a suite of intermediary loggers that can be chained together to customize a logging system that works for your project. All of these intermediary loggers make use of the ILogger interface, so they work perfectly fine with custom implementations.

## Logger Types

### ILogger
ILogger is a simple interface consisting of a single method: Log(string, LogLevel). ILogger.cs also defines the LogLevel enum, which has the following values: Debug, Info, Warn, Error, and Critical, in order from least to most dire. 

### FileLogger
FileLogger is a functional logger that writes messages to a file. If created with the parameter 'overwrite' set to false, the FileLogger will continue to append lines to the specified file if it already exists.

### ConsoleLogger
ConsoleLogger is a functional logger that displays messages on the console. Messages are color coded based on severity, and the colors are fully customizable. 

### LeveledLogger
LeveledLogger is an intermediary logger that filters out messages based on severity. Messages with severity lower than the LeveledLogger's threshold are filtered out and not recorded by the internal logger.

### MultiLogger
Multilogger is an intermediary logger that forwards messages to any number of internal ILogger objects. A MultiLogger can be used with a FileLogger and a ConsoleLogger, for instance, to record messages both in a file and on screen. 

### FormatLogger
FormatLogger is provided as a top-level logger. In addition to formatting messages automatically, it also features convenience wrappers for each severity level.
Though it is intended to function as the top level in a chain of loggers, FormatLogger still implements ILogger, and therefore can be used as an intermediary.

## Recommended Usage
HLogger is a modular system, and most of its customization comes from the structure of intermediary loggers chained together. For example, by using a MultiLogger to split messages between two LeveledLoggers, one of which forwards to a ConsoleLogger and the other to a FileLogger, you can display only warning and error messages on the console, but record debugging information in the log file using the same object. Or, you could have seperate FileLoggers for debug and error information, writing to different files.
You can also write your own implementations for the ILogger interface, either as intermediaries or as functional outputs for your project.
