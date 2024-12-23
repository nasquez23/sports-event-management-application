using System.ComponentModel.DataAnnotations;

namespace SportsEventsAdminApplication.Models
{
    public class Match
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
