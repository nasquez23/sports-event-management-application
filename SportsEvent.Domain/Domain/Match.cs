using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.Domain
{
    public class Match: BaseEntity 
    {

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? Score { get; set; }
        public Guid TeamId1 { get; set; }
        public Guid TeamId2 { get; set; }

        public Guid SportEventId { get; set; }

        public SportEvent? SportEvent { get; set; }
    }
}
