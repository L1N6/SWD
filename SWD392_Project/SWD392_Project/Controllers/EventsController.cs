using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SWD392_Project.Models;

namespace SWD392_Project.Controllers
{
    public class EventsController : Controller
    {
        private readonly Swd392Project1Context _context;

        public EventsController(Swd392Project1Context context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var swd392Project1Context = _context.Events.Include(e => e.Account).Include(e => e.Category).Include(e => e.State);
            return View(await swd392Project1Context.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Account)
                .Include(e => e.Category)
                .Include(e => e.State)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Name,Description,StartDate,EndDate,Location,CategoryId,AccountId,StateId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", @event.AccountId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", @event.CategoryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", @event.StateId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", @event.AccountId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", @event.CategoryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", @event.StateId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("EventId,Name,Description,StartDate,EndDate,Location,CategoryId,AccountId,StateId")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", @event.AccountId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", @event.CategoryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", @event.StateId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Account)
                .Include(e => e.Category)   
                .Include(e => e.State)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'Swd392Project1Context.Events'  is null.");
            }
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(long id)
        {
          return (_context.Events?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
