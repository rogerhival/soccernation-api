using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
