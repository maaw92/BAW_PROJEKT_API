using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Api_Test.Models;

namespace Core_Api_Test.Controllers
{
    public class ManagerController : Controller
    {
        private readonly DefaultDbContext _context;

        public ManagerController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: Manager
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieEvents.ToListAsync());
        }

        // GET: Manager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEvent = await _context.MovieEvents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieEvent == null)
            {
                return NotFound();
            }

            return View(movieEvent);
        }

        // GET: Manager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date")] MovieEvent movieEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieEvent);
        }

        // GET: Manager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEvent = await _context.MovieEvents.FindAsync(id);
            if (movieEvent == null)
            {
                return NotFound();
            }
            return View(movieEvent);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date")] MovieEvent movieEvent)
        {
            if (id != movieEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieEventExists(movieEvent.Id))
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
            return View(movieEvent);
        }

        // GET: Manager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEvent = await _context.MovieEvents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieEvent == null)
            {
                return NotFound();
            }

            return View(movieEvent);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieEvent = await _context.MovieEvents.FindAsync(id);
            if (movieEvent != null)
            {
                _context.MovieEvents.Remove(movieEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieEventExists(int id)
        {
            return _context.MovieEvents.Any(e => e.Id == id);
        }
    }
}
