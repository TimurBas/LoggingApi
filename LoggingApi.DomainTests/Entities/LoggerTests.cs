using LoggingApi.Domain.Factories;
using LoggingApi.Domain.Shared;
using LoggingApi.Domain.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace LoggingApi.Domain.Entities.Tests
{
    [TestClass()]
    public class LoggerTests
    {
        private Logger _logger;
        public LoggerTests()
        {
            _logger = new Logger(new LogFactory());
        }

        [TestMethod()]
        public void ConstructorTest()
        {
            Assert.AreEqual(@"C:\logs\", _logger.BasePath);
            Assert.AreEqual(2, _logger.DataFormatStrategies.Count);
            Assert.AreEqual(true, _logger.IsSystemConsoleEnabled);
        }

        [TestMethod()]
        public void ProcessEventTest()
        {
            var validLogEvent = new LogEvent(LogLevel.Error, "CS2021", new LogException("Missing ,", "At line 121"));
            _logger.ProcessEvent(validLogEvent);

            var date = DateTime.Now;

            var doesJsonFileExist = File.Exists(@$"{_logger.BasePath}json\{date.ToString("yyMMdd")}.json");
            var doesXmlFileExist = File.Exists(@$"{_logger.BasePath}xml\{date.ToString("yyMMdd_HH")}.xml");

            Assert.AreEqual(doesJsonFileExist, true);
            Assert.AreEqual(doesXmlFileExist, true);
        }
    }
}

