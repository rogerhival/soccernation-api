using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soccernation.Models.Enums;

namespace Soccernation.Models
{
    public class Competition : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public List<Team> Teams { get; set; }
        public List<Match> Matches { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Status { get; set; }
    }
}
