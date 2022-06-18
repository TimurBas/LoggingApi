using LoggingApi.Data.Models;
using LoggingApi.Domain.Entities;
using LoggingApi.Domain.Values;

namespace LoggingApi.App.Mapper
{
    public static class Mapper
    {
        public static LogDto MapLogEventToDto(LogEvent logEvent)
        {
            return new LogDto()
            {
                Level = logEvent.Level.ToString(),
                Message = logEvent.Message,
                CreatedOn = logEvent.CreatedOn,
                Exception = MapExceptionToDto(logEvent.Exception)
            };
        }

        private static LogExceptionDto MapExceptionToDto(LogException exception)
        {
            return new LogExceptionDto()
            {
                Message = exception.Message,
                Stacktrace = exception.Stacktrace
            };
        }
    }
}
