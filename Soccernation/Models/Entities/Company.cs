using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public string StreetName { get; set; }
        public int UnitNumber { get; set; }
        public string Suburb { get; set; }
        public string PostalCode { get; set; }

        public Continent Continent { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public State State { get; set; }

        public string Website { get; set; }
        public string ContactNumber { get; set; }
        public string ExtraContactNumber { get; set; }
        public string Email { get; set; }

        public List<Competition> Competitions { get; set; }
    }
}
