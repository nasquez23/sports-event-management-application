using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsEvent.Domain.Domain;
using SportsEvent.Service.Interface;

namespace SportsEventApp.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly ITeamService _teamService;
        private readonly ISportEventService _sportEventService;
        private readonly ITicketService _ticketService;

        public MatchesController(IMatchService matchService, ITeamService teamService, ISportEventService sportEventService, ITicketService ticketService)
        {
            _matchService = matchService;
            _teamService = teamService;
            _sportEventService = sportEventService;
            _ticketService = ticketService;
        }



        // GET: Matches
        public IActionResult Index()
        {
            ViewData["TeamNames"] = _teamService.GetAllTeams().ToDictionary(t => t.Id, t => t.Name);
            ViewData["SportEventNames"] = _sportEventService.GetAllSportEvents().ToDictionary(se => se.Id, se => se.Name);

            return View(_matchService.GetAllMatches());
        }

        // GET: Matches/Details/5
        public IActionResult Details(Guid? id)
        {
            ViewData["TeamNames"] = _teamService.GetAllTeams().ToDictionary(t => t.Id, t => t.Name);
            ViewData["SportEventNames"] = _sportEventService.GetAllSportEvents().ToDictionary(se => se.Id, se => se.Name);

            if (id == null)
            {
                return NotFound();
            }

            Match match = _matchService.GetMatch(id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            List<Team> teams = _teamService.GetAllTeams();
            ViewData["Team1Id"] = new SelectList(teams, "Id", "Name");
            ViewData["Team2Id"] = new SelectList(teams, "Id", "Name");
            ViewData["SportEventId"] = new SelectList(_sportEventService.GetAllSportEvents(), "Id", "Name");

            return View();
        }

        // POST: Matches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Date,Location,Score,TeamId1,TeamId2,SportEventId,Id")] Match match)
        {
            if (ModelState.IsValid)
            {
                match.Id = Guid.NewGuid();
                _matchService.AddMatch(match);

                return RedirectToAction(nameof(Index));
            }

            ViewData["Team1Id"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", match.TeamId1);
            ViewData["Team2Id"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", match.TeamId2);
            ViewData["SportEventId"] = new SelectList(_sportEventService.GetAllSportEvents(), "Id", "Name", match.SportEventId);

            return View(match);
        }

        // GET: Matches/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _matchService.GetMatch(id);
            if (match == null)
            {
                return NotFound();
            }

            ViewData["Team1Id"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", match.TeamId1);
            ViewData["Team2Id"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", match.TeamId2);
            ViewData["SportEventId"] = new SelectList(_sportEventService.GetAllSportEvents(), "Id", "Name", match.SportEventId);

            return View(match);
        }

        // POST: Matches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Date,Location,Score,TeamId1,TeamId2,SportEventId,Id")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _matchService.UpdateMatch(match);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            ViewData["Team1Id"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", match.TeamId1);
            ViewData["Team2Id"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", match.TeamId2);
            ViewData["SportEventId"] = new SelectList(_sportEventService.GetAllSportEvents(), "Id", "Name", match.SportEventId);

            return View(match);
        }

        // GET: Matches/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match match = _matchService.GetMatch(id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Match match = _matchService.GetMatch(id);
            if (match != null)
            {
                _matchService.DeleteMatch(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(Guid id)
        {
            return _matchService.GetMatch(id) != null;
        }


        public IActionResult BuyTicket(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _matchService.GetMatch(id);

            Ticket t = new Ticket();

            if (t != null)
            {
                t.MatchId= match.Id;
                t.Match = match;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 
            }

            return View(t);
        }

        [HttpPost]
        public IActionResult TicketBought(Ticket model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _ticketService.CreateTicket(model);



            return View("Index", _ticketService.GetAllTickets());
        }

    }
}
