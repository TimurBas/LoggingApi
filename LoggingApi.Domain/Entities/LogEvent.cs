using System;

namespace LoggingApi.Domain.Entities
{
    public class LogEvent
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public LogEvent() { }
        public LogEvent(LogLevel level, string message)
        {
            Level = level;
            Message = message;
            CreatedOn = DateTime.Now;
        }
    }
    public enum LogLevel
    {
        Verbose,
        Debug,
        Information,
        Warning,
        Error,
        Fatal
    }
}
