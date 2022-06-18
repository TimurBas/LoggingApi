using System.ComponentModel.DataAnnotations;

namespace LoggingApi.Data.Models
{
    public class LogExceptionDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Stacktrace { get; set; }
    }
}
