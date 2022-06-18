using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoggingApi.Data.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
