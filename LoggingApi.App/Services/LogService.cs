using LoggingApi.App.Models;
using LoggingApi.Data.Contexts;
using LoggingApi.Data.Models;
using LoggingApi.Domain;
using LoggingApi.Domain.Entities;
using LoggingApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggingApi.App.Services
{
    public class LogService : ILogService
    {
        private readonly LogContext _context;
        private readonly Logger _logger;
        public LogService(LogContext context, Logger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddLogEvent(Event @event)
        {
            var mappedLogLevel = Enum.Parse<LogLevel>(@event.LogLevel); // TryParse instead
            var logEvent = new LogEvent(mappedLogLevel, @event.LogMessage, @event.LogException);
            _logger.ProcessEvent(logEvent);
            var mappedLogEvent = Mapper.Mapper.MapLogEventToDto(logEvent); // Since we don't use the repository pattern we just do it here
            _context.Logs.Add(mappedLogEvent);
            _context.SaveChanges();
        }

        public List<LogDto> GetAllLogEvents()
        {
            return _context.Logs.Include(log => log.Exception).ToList();
        }
    }
}
