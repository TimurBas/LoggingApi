using LoggingApi.Domain.Shared;
using LoggingApi.Domain.Values;
using System;

namespace LoggingApi.Domain.Entities
{
    public class LogEvent
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public LogException Exception { get; set; }
        public LogEvent() { }
        public LogEvent(LogLevel level, string message, LogException exception)
        {
            Level = level;
            Message = message;
            Exception = exception;
            CreatedOn = DateTime.Now;
        }
    }
}
