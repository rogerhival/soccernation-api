using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Team : EntityAbstract
    {
        [Required]
        public string Name { get; set; }
        public string LogoImage { get; set; }

        public List<Player> Players { get; set; }
    }
}
