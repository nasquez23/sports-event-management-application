using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.Domain
{
    public class Team : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sport { get; set; }
        [Required]
        public string Coach { get; set; }
       

        public ICollection<Player>? Players { get; set; }

        public ICollection<Match>? Matches { get; set; }
    }
}
