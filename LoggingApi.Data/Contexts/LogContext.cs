using LoggingApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LoggingApi.Data.Contexts
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions<LogContext> options)
            : base(options)
        {

        }
        public DbSet<LogDto> Logs { get; set; }
        public DbSet<LogExceptionDto> Exceptions {get; set;}
    }
}
