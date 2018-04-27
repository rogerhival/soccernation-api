using Soccernation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedOnUtc { get; set; }
        DateTime ModifiedOnUtc { get; set; }
        string Status { get; set; }
    }
}
