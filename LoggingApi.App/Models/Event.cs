﻿using LoggingApi.Domain.Entities;

namespace LoggingApi.App.Models
{
    public class Event
    {
        public string LogLevel { get; set; }
        public string LogMessage { get; set; }
        //public LogException LogException { get; set; }
    }
}
