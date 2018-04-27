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
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public List<Fixture> Fixtures { get; set; }
        public List<Court> Courts { get; set; }

        public decimal? SubscriptionPrice { get; set; }
        public string TypeOfCompetition { get; set; }
        public List<ResultRow> Results { get; set; }
    }
}
