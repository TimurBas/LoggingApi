using LoggingApi.Domain.Factories;
using LoggingApi.Domain.Shared;
using LoggingApi.Domain.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggingApi.Domain.Entities
{
    public class Logger
    {
        public string BasePath { get; init; }
        public bool IsSystemConsoleEnabled { get; init; }
        public IList<IDataFormatStrategy> DataFormatStrategies { get; init; }
        private readonly bool HasBasePath = false;
        public Logger(ILogFactory logFactory)
        {
            BasePath = logFactory.CreateBasePath();
            if (!string.IsNullOrEmpty(BasePath))
                HasBasePath = true;
            IsSystemConsoleEnabled = logFactory.CreateCanWriteToSystemConsole();
            DataFormatStrategies = logFactory.CreateDataFormatStrategy();
        }

        /*
         * Not fully implemented: When written "return" it should propagate an exception / failure to the API-layer
         * in order to return the correct status code.
         */
        public void ProcessEvent(LogEvent logEvent)
        {
            var logLevelNames = Enum.GetNames<LogLevel>().ToList();
            var logLevelInt = (int)logEvent.Level;
            var logLevelInformationInt = (int)LogLevel.Information;

            var isLogLevelOutOfBounds = logLevelInt > logLevelNames.Count || logLevelInt < logLevelInformationInt;
            if (isLogLevelOutOfBounds)
            {
                return; 
            }

            if (!HasBasePath || DataFormatStrategies.Count < 1)
                return;

            if (IsSystemConsoleEnabled || logLevelInt >= logLevelInformationInt)
            {
                WriteEventToStandardOutput(logEvent);
            }

            foreach (IDataFormatStrategy dataFormatStrategy in DataFormatStrategies)
            {
                dataFormatStrategy.HandleLogEvent(logEvent, BasePath);
            }
        }

        private void WriteEventToStandardOutput(LogEvent logEvent)
        {
            Console.WriteLine($"\nLog Event at {logEvent.CreatedOn}");
            Console.WriteLine($"Level: {logEvent.Level}");
            Console.WriteLine($"Message: {logEvent.Message}\n");
        }
    }
}
