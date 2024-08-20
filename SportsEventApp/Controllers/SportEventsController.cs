using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsEvent.Domain.Domain;
using SportsEventApp.Data;

namespace SportsEventApp.Controllers
{
    public class SportEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SportEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SportEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.SportEvent.ToListAsync());
        }

        // GET: SportEvents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = await _context.SportEvent
                .FirstOrDefaultAsync(m => m.Id == id);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Start,End,Id")] SportEvent sportEvent)
        {
            if (ModelState.IsValid)
            {
                sportEvent.Id = Guid.NewGuid();
                _context.Add(sportEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportEvent);
        }

        // GET: SportEvents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = await _context.SportEvent.FindAsync(id);
            if (sportEvent == null)
            {
                return NotFound();
            }
            return View(sportEvent);
        }

        // POST: SportEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Start,End,Id")] SportEvent sportEvent)
        {
            if (id != sportEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportEvent);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = await _context.SportEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportEvent == null)
            {
                return NotFound();
            }

            return View(sportEvent);
        }

        // POST: SportEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sportEvent = await _context.SportEvent.FindAsync(id);
            if (sportEvent != null)
            {
                _context.SportEvent.Remove(sportEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportEventExists(Guid id)
        {
            return _context.SportEvent.Any(e => e.Id == id);
        }
    }
}
