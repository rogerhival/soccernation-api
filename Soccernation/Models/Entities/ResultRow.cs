using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class ResultRow : EntityAbstract
    {
        public short Position { get; set; }
        public Team Team { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public int Forfeits { get; set; }
        public int ConcedeForfeits { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }

        public int Bonus => GoalsFor - GoalsAgainst;
        public int Points => ((Wins + Forfeits) * 3) + Draws;
    }
}
