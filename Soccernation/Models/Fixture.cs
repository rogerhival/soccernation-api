using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Fixture : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Round { get; set; }

        [Required]
        public Team TeamHome { get; set; }
        [Required]
        public Team TeamVisitor { get; set; }

        public int TeamHomeScore { get; set; }
        public int TeamVisitorScore { get; set; }

        public string Status { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
