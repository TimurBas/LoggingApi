using LoggingApi.App.Models;
using LoggingApi.App.Services;
using LoggingApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LoggingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogService _service;

        public LogController(ILogService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddLogEvent([FromBody] Event @event)
        {
            // Note no error handling
            _service.AddLogEvent(@event);
            return Ok("Added log event!");
        }

        [HttpGet]
        public ActionResult<List<Log>> GetAllLogEvents()
        {
            var logsEvents = _service.GetAllLogEvents();
            return Ok(logsEvents);
        }
    }
}
