using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsEvent.Domain.Domain;

namespace SportsEvent.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicket(Guid? id);
        void CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Guid id);
    }
}