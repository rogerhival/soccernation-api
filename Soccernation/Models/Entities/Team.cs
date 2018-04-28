using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Team : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string LogoImage { get; set; }

        [NotMapped]
        [DefaultValue(false)]
        public bool HasPaid { get; set; } // Competition payment control, until we get a better option

        public List<Player> Players { get; set; }
    }
}
