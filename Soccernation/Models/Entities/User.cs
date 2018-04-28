using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime? ExpireDateUTC { get; set; }
        [DefaultValue(false)]
        public bool HasPremium { get; set; }

        public Player Player { get; set; }
        public Company Company { get; set; }
        public Manager Manager { get; set; }
    }
}
