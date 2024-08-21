using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.Domain
{
    public class Player : BaseEntity
    {
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? Position { get; set; }
        public Guid TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
