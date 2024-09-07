using SportsEvent.Domain.Domain;
using SportsEvent.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDTO getShoppingCartInfo(string userId);
        bool deleteTicketFromShoppingCart(string userId, Guid ticketId);
        bool order(string userId);
        bool AddToShoppingConfirmed(TicketInShoppingCart model, string userId);


    }
}
