using System;
using System.ComponentModel.DataAnnotations;

namespace Soccernation.Models
{
    public class CompetitionsCourts : EntityAbstract
    {
        [Required]
        public Competition Competition { get; set; }
        [Required]
        public Court Court { get; set; }

        public TimeSpan StartTime { get; set; } //this range should be inside competition's range
        public TimeSpan EndTime { get; set; }
    }
}
