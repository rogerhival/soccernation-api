using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Continent : BaseEntity
    {
        //The idea creating continent is to therefore shows it on a world map
        //Example: http://results.sportskeepglobal.com/# of course totally different.. enabling statistics around the globe would be nice, don't need to use in the version 1
        public string Name { get; set; }
        public List<Country> Countries { get; set; }
    }
}
