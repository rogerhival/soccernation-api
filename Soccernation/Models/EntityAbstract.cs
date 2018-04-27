using Soccernation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public abstract class EntityAbstract : IEntity
    {
        public EntityAbstract()
        {
            CreatedOn = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
        public string Status { get; set; }
    }
}
