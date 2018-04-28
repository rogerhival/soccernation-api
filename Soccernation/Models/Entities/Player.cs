using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public class Player : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string AvatarThumb { get; set; }
        public string AvatarLarge { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string PreferredPosition { get; set; }
        public string Gender { get; set; }
    }
}
