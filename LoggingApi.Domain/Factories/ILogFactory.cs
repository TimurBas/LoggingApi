using LoggingApi.Domain.Strategies;
using System.Collections.Generic;

namespace LoggingApi.Domain.Factories
{
    public interface ILogFactory
    {
        string CreateBasePath();
        IList<IDataFormatStrategy> CreateDataFormatStrategy();
        bool CreateCanWriteToSystemConsole();
    }
}
