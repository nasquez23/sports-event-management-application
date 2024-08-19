using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.Domain
{
    public class Match: BaseEntity 
    { 
       
        [Required]
        public string Date { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Score { get; set; }
        public Guid TeamId { get; set; }
        public Team? Team { get; set; }
        [Required]
        public string Teams { get; set; }

        public Guid SportEventId { get; set; }

        public SportEvent? SportEvent { get; set; }
    }
}
