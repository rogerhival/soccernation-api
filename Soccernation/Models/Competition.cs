using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Soccernation.Models.Enums;

namespace Soccernation.Models
{
    public class Competition : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Team> Teams { get; set; }
        public List<Fixture> Fixtures { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Status { get; set; }
        public List<ResultRow> Results { get; set; }
    }
}
