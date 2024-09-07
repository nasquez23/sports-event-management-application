using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsEvent.Domain.Domain;
using SportsEvent.Service.Interface;

namespace SportsEventApp.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        public PlayersController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        // GET: Players
        public IActionResult Index()
        {
            return View(_playerService.GetAllPlayers());
        }

        // GET: Players/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = _playerService.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name");
            Console.WriteLine("$Teams = {_teamService.GetAllTeams()}");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Age,Country,Position,TeamId,Id")] Player player)
        {
            if (ModelState.IsValid)
            {
                player.Id = Guid.NewGuid();
                _playerService.AddPlayer(player);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = _playerService.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("FirstName,LastName,Age,Country,Position,TeamId,Id")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _playerService.UpdatePlayer(player);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            ViewData["TeamId"] = new SelectList(_teamService.GetAllTeams(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = _playerService.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var player = _playerService.GetPlayer(id);
            if (player != null)
            {
                _playerService.DeletePlayer(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(Guid id)
        {
            return _playerService.GetPlayer(id) != null;
        }
    }
}
