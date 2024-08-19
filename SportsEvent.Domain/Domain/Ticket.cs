using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvent.Domain.Identity;
namespace SportsEvent.Domain.Domain
{
    public class Ticket : BaseEntity
    {
        public Guid MatchId { get; set; }
        public Match? Match { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Rating { get; set; }
        public virtual SportsEventApplicationUser? CreatedBy { get; set; }
        
    }
}
