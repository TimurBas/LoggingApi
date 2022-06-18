using LoggingApi.Data.Models;
using LoggingApi.Domain.Entities;

namespace LoggingApi.App.Mapper
{
    public static class Mapper
    {
        public static Log MapLogEventToDbModel(LogEvent logEvent)
        {
            return new Log()
            {
                Level = logEvent.Level.ToString(),
                Message = logEvent.Message,
                CreatedOn = logEvent.CreatedOn,
                Exception = ""
            };
        }
    }
}
