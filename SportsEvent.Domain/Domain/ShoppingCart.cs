using SportsEvent.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.Domain
{
    public class ShoppingCart:BaseEntity
    {
        public string? OwnerId { get; set; }    

        public SportsEventApplicationUser? Owner { get; set; }

        public virtual ICollection<TicketInShoppingCart>? TicketsInShoppingCarts { get; set; }

    }
}
