using System;
using System.ComponentModel.DataAnnotations;

namespace Soccernation.Models
{
    public class Court : EntityAbstract
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required]
        public string Description { get; set; }
        public string Type { get; set; } // same as competition, will control if the court is futsal, 7, 11
    }
}
