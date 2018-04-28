using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public List<State> States { get; set; }
    }
}
