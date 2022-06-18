using LoggingApi.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LoggingApi.Domain.Strategies
{
    public class JsonStrategy : IDataFormatStrategy
    {
        private LogEvent _event;
        private string _fullPath;
        public void HandleLogEvent(LogEvent @event, string basePath)
        {
            _event = @event;
            var date = @event.CreatedOn.ToString("yyMMdd");
            _fullPath = $@"{basePath}json\{date}.json";
            var fileExists = File.Exists(_fullPath);
            if (fileExists)
            {
                WriteToExistingFile();
            } 
            else
            {
                WriteToNewFile();
            }
        }

        public void WriteToExistingFile()
        {
            var json = File.ReadAllText(_fullPath);
            var logs = JsonSerializer.Deserialize<List<LogEvent>>(json);
            logs.Add(_event);
            var updatedJson = JsonSerializer.Serialize(logs);
            File.WriteAllText(_fullPath, updatedJson);
        }

        public void WriteToNewFile()
        {
            var eventWrapper = new List<LogEvent>() { _event };
            var json = JsonSerializer.Serialize(eventWrapper);
            File.WriteAllText(_fullPath, json);
        }
    }
}
