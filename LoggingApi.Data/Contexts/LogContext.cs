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
        public DbSet<Log> Logs { get; set; }
    }
}
