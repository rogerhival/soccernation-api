using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Fixture : BaseEntity
    {

        [Required]
        public DateTime DateUtc { get; set; }

        [Required]
        public int Round { get; set; }

        [Required]
        public Team TeamHome { get; set; }
        [Required]
        public Team TeamVisitor { get; set; }
        
        public Court Court { get; set; }

        public int TeamHomeScore { get; set; }
        public int TeamVisitorScore { get; set; }
        public int Leg { get; set; }
    }
}
