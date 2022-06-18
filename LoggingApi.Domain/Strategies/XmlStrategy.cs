using LoggingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LoggingApi.Domain.Strategies
{
    public class XmlStrategy : IDataFormatStrategy
    {
        private LogEvent _event;
        private string _fullPath;
        private XmlSerializer _xmlSerializer;
        public void HandleLogEvent(LogEvent @event, string basePath)
        {
            _xmlSerializer = new XmlSerializer(typeof(List<LogEvent>));
            _event = @event;
            var date = DateTime.Now.ToString("yyMMdd_HH");
            _fullPath = $@"{basePath}xml\{date}.xml";
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
            var xml = File.ReadAllText(_fullPath);
            using (var reader = new StringReader(xml))
            {
                var logs = (List<LogEvent>)_xmlSerializer.Deserialize(reader);
                logs.Add(_event);
                Write(logs);
            }
        }

        public void WriteToNewFile()
        {
            var eventWrapper = new List<LogEvent>() { _event };
            Write(eventWrapper);
        }

        public void Write(List<LogEvent> logs)
        {
            var fileStream = new FileStream(_fullPath, FileMode.Create);
            var writer = new StreamWriter(fileStream, new UTF8Encoding());
            _xmlSerializer.Serialize(writer, logs);
            writer.Close();
        }
    }
}
