using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReadingList;
using ReadingList.Models;

namespace ReadingList.Controllers
{
    public class MovieLocationsController : Controller
    {
        private readonly ReadingContext _context;

        public MovieLocationsController(ReadingContext context)
        {
            _context = context;
        }

        // GET: MovieLocations
        public async Task<IActionResult> Index()
        {
            var readingContext = _context.MovieLocations.Include(m => m.Location).Include(m => m.Movie);
            return View(await readingContext.ToListAsync());
        }

        // GET: MovieLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieLocation = await _context.MovieLocations
                .Include(m => m.Location)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieLocation == null)
            {
                return NotFound();
            }

            return View(movieLocation);
        }

        // GET: MovieLocations/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            return View();
        }

        // POST: MovieLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,LocationId,SpanishAudio,URL,Format,Cost,Price")] MovieLocation movieLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", movieLocation.LocationId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieLocation.MovieId);
            return View(movieLocation);
        }

        // GET: MovieLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieLocation = await _context.MovieLocations.FindAsync(id);
            if (movieLocation == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", movieLocation.LocationId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieLocation.MovieId);
            return View(movieLocation);
        }

        // POST: MovieLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,LocationId,SpanishAudio,URL,Format,Cost,Price")] MovieLocation movieLocation)
        {
            if (id != movieLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieLocationExists(movieLocation.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", movieLocation.LocationId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieLocation.MovieId);
            return View(movieLocation);
        }

        // GET: MovieLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieLocation = await _context.MovieLocations
                .Include(m => m.Location)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieLocation == null)
            {
                return NotFound();
            }

            return View(movieLocation);
        }

        // POST: MovieLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieLocation = await _context.MovieLocations.FindAsync(id);
            _context.MovieLocations.Remove(movieLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieLocationExists(int id)
        {
            return _context.MovieLocations.Any(e => e.Id == id);
        }
    }
}
