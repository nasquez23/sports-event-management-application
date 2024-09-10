using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsEvent.Domain.Domain;
using SportsEvent.Service.Implementation;
using SportsEvent.Service.Interface;
using SportsEventApp.Repository;

namespace SportsEventApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;
        private readonly IMatchService matchService;

        private readonly IShoppingCartService shoppingCartService;

        public TicketsController(ITicketService ticketService, IMatchService matchService, IShoppingCartService shoppingCartService)
        {
            this.ticketService = ticketService;
            this.matchService = matchService;
            this.shoppingCartService = shoppingCartService;
        }


        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var tickets = ticketService.GetAllTickets();
            return View(tickets);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = ticketService.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["MatchId"] = new SelectList(matchService.GetAllMatches(), "Id", "Location");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchId,Price,Tribina,Red,Sedishte,Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Id = Guid.NewGuid();
                ticketService.CreateTicket(ticket);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatchId"] = new SelectList(matchService.GetAllMatches(), "Id", "Location", ticket.MatchId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = ticketService.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["MatchId"] = new SelectList(matchService.GetAllMatches(), "Id", "Location", ticket.MatchId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MatchId,Price,Tribina,Red,Sedishte,Id")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ticketService.UpdateTicket(ticket);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatchId"] = new SelectList(matchService.GetAllMatches(), "Id", "Location", ticket.MatchId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = ticketService.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ticket = ticketService.GetTicket(id);
            if (ticket != null)
            {
                ticketService.DeleteTicket(id);
            }

           return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return ticketService.GetTicket(id) != null;
        }

        public IActionResult AddToCart(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = ticketService.GetTicket(id);

            TicketInShoppingCart ts = new TicketInShoppingCart();

            if (ts != null)
            {
                ts.TicketId = match.Id;
                ts.Ticket = match;
                

            }

            return View(ts);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(TicketInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            shoppingCartService.AddToShoppingConfirmed(model, userId);



            return View("Index", ticketService.GetAllTickets());
        }
    }
}
