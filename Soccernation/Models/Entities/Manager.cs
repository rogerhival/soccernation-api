using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Manager : BaseEntity
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public Team Team { get; set; }
    }
}
