using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string AreaCode { get; set; } // for phone numbers MAYBE
    }
}
