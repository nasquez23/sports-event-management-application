using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SportsEventsAdminApplication.Models
{
    public class Ticket
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
