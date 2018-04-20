using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Team : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public List<Player> Players { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
