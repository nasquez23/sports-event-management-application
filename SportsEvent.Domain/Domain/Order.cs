using SportsEvent.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.Domain
{
    public class Order:BaseEntity
    {
        public string? userId { get; set; }
        public SportsEventApplicationUser? Owner { get; set; }
        public IEnumerable<TicketInOrder>? TicketsInOrder { get; set; }
    }
}
