using System.ComponentModel.DataAnnotations;

namespace SportsEventsAdminApplication.Models
{
    public class SportEvent
    {

        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public virtual ICollection<Match>? Matches { get; set; }


    }
}
