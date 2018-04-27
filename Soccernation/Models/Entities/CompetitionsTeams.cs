using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class CompetitionsTeams : EntityAbstract
    {
        public Team Team { get; set; }
        public Competition Competition { get; set; }

        [DefaultValue(false)]
        public bool HasPaid { get; set; }
    }
}
