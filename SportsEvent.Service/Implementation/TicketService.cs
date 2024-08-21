using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvent.Domain.Domain;
using SportsEvent.Repository.Interface;
using SportsEvent.Service.Interface;

namespace SportsEvent.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<Match> _matchRepository;

        public TicketService(IRepository<Ticket> ticketRepository, IRepository<Match> matchRepository)
        {
            _ticketRepository = ticketRepository;
            _matchRepository = matchRepository;
        }

        public Ticket GetTicket(Guid? ticketId)
        {
            return _ticketRepository.Get(ticketId);
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll().ToList();
        }

        public void CreateTicket(Ticket ticket)
        {
            ticket.Match = _matchRepository.Get(ticket.MatchId);
            _ticketRepository.Insert(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            ticket.Match = _matchRepository.Get(ticket.MatchId);
            _ticketRepository.Update(ticket);
        }

        public void DeleteTicket(Guid ticketId)
        {
            _ticketRepository.Delete(_ticketRepository.Get(ticketId));
        }
    }
}
