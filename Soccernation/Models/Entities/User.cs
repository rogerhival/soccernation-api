using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class User : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [Required]
        public byte[] Key { get; set; }
        [Required]
        public byte[] KeySalt { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime? LastTimeLoginUtc { get; set; }
        public DateTime? ExpireDateUtc { get; set; }
        [DefaultValue(false)]
        public bool HasPremium { get; set; }

        public Player Player { get; set; }
        public Company Company { get; set; }
        public Manager Manager { get; set; }
    }

    public class LoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
