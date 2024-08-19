using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.Domain
{
    public class SportEvent : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Start { get; set; }
        [Required]
        public string End { get; set; }
        public ICollection<Match>? Matches { get; set; }

    }
}
