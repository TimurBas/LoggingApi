using LoggingApi.App.Models;
using LoggingApi.Data.Models;
using System.Collections.Generic;

namespace LoggingApi.App.Services
{
    public interface ILogService
    {
        void AddLogEvent(Event @event);
        List<LogDto> GetAllLogEvents();
    }
}
