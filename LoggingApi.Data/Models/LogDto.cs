using System;
using System.ComponentModel.DataAnnotations;

namespace LoggingApi.Data.Models
{
    public class LogDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Level { get; set; }
        public string Message { get; set; }
        public virtual LogExceptionDto Exception { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
