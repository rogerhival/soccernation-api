using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Soccernation.Models.Enums;

namespace Soccernation.Models
{
    public class Competition : EntityAbstract
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Fixture> Fixtures { get; set; }

        public List<ResultRow> Results { get; set; }
    }
}
