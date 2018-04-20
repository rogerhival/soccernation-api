using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Match : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public Team TeamHome { get; set; }
        public Team TeamVisitor { get; set; }

        public int TeamHomeScore { get; set; }
        public int TeamVisitorScore { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
