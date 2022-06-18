using LoggingApi.Domain.Strategies;
using System.Collections.Generic;

namespace LoggingApi.Domain.Factories
{
    public class LogFactory : ILogFactory
    {
        public string CreateBasePath()
        {
            return @"C:\logs\";
        }

        public IList<IDataFormatStrategy> CreateDataFormatStrategy()
        {
            return new List<IDataFormatStrategy>()
            {
                new JsonStrategy(),
                new XmlStrategy()
            };
        }

        public bool CreateCanWriteToSystemConsole()
        {
            return true;
        }
    }
}
