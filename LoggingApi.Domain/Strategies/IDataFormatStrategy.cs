using LoggingApi.Domain.Entities;

namespace LoggingApi.Domain.Strategies
{
    public interface IDataFormatStrategy
    {
        void WriteToNewFile();
        void WriteToExistingFile();
        void HandleLogEvent(LogEvent @event, string basePath);
    }
}
