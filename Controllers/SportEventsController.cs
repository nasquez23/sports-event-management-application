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
    public class SportEventsController : Controller
    {
        private readonly ISportEventService _sportEventService;

        public SportEventsController(ISportEventService sportEventService)
        {
            _sportEventService = sportEventService;
        }

        // GET: SportEvents
        public IActionResult Index()
        {
            return View(_sportEventService.GetAllSportEvents());
        }

        // GET: SportEvents/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = _sportEventService.GetSportEvent(id);
            if (sportEvent == null)
            {
                return NotFound();
            }

            return View(sportEvent);
        }

        // GET: SportEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportEvents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Start,End,Id")] SportEvent sportEvent)
        {
            if (ModelState.IsValid)
            {
                sportEvent.Id = Guid.NewGuid();
                _sportEventService.CreateSportEvent(sportEvent);
                return RedirectToAction(nameof(Index));
            }
            return View(sportEvent);
        }

        // GET: SportEvents/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = _sportEventService.GetSportEvent(id);
            if (sportEvent == null)
            {
                return NotFound();
            }
            return View(sportEvent);
        }

        // POST: SportEvents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Start,End,Id")] SportEvent sportEvent)
        {
            if (id != sportEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _sportEventService.UpdateSportEvent(sportEvent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportEventExists(sportEvent.Id))
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
            return View(sportEvent);
        }

        // GET: SportEvents/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = _sportEventService.GetSportEvent(id);
            if (sportEvent == null)
            {
                return NotFound();
            }

            return View(sportEvent);
        }

        // POST: SportEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var sportEvent = _sportEventService.GetSportEvent(id);
            if (sportEvent != null)
            {
                _sportEventService.DeleteSportEvent(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SportEventExists(Guid id)
        {
            return _sportEventService.GetSportEvent(id) != null;
        }
    }
}
