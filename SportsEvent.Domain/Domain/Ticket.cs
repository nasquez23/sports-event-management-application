using SportsEvent.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.Domain
{
    public class Ticket:BaseEntity
    {
        public Guid MatchId { get; set; }
        public Match? Match { get; set; }
        [Required]
        public double Price { get; set; }

        public string? Tribina { get; set; }

        public int Red { get; set; }

        public int Sedishte { get; set; }
        public virtual SportsEventApplicationUser? CreatedBy { get; set; }
    }
}
