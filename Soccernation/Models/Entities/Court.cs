using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soccernation.Models
{
    public class Court : EntityAbstract
    {
        [NotMapped]
        public TimeSpan StartTime { get; set; }
        [NotMapped]
        public TimeSpan EndTime { get; set; }
        //NOTMAPPED, because we don't want this properties in the DB, but we want it to come by json to insert the relationship

        [Required]
        public string Description { get; set; }
        public string Type { get; set; } // same as competition, will control if the court is futsal, 7, 11
    }
}
