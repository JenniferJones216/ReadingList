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
    public class MoviePrizesController : Controller
    {
        private readonly ReadingContext _context;

        public MoviePrizesController(ReadingContext context)
        {
            _context = context;
        }

        // GET: MoviePrizes
        public async Task<IActionResult> Index()
        {
            var readingContext = _context.MoviePrizes.Include(m => m.Movie).Include(m => m.Prize);
            return View(await readingContext.ToListAsync());
        }

        // GET: MoviePrizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePrize = await _context.MoviePrizes
                .Include(m => m.Movie)
                .Include(m => m.Prize)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviePrize == null)
            {
                return NotFound();
            }

            return View(moviePrize);
        }

        // GET: MoviePrizes/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["PrizeId"] = new SelectList(_context.Prizes, "Id", "Id");
            return View();
        }

        // POST: MoviePrizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,PrizeId")] MoviePrize moviePrize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviePrize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", moviePrize.MovieId);
            ViewData["PrizeId"] = new SelectList(_context.Prizes, "Id", "Id", moviePrize.PrizeId);
            return View(moviePrize);
        }

        // GET: MoviePrizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePrize = await _context.MoviePrizes.FindAsync(id);
            if (moviePrize == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", moviePrize.MovieId);
            ViewData["PrizeId"] = new SelectList(_context.Prizes, "Id", "Id", moviePrize.PrizeId);
            return View(moviePrize);
        }

        // POST: MoviePrizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,PrizeId")] MoviePrize moviePrize)
        {
            if (id != moviePrize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviePrize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviePrizeExists(moviePrize.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", moviePrize.MovieId);
            ViewData["PrizeId"] = new SelectList(_context.Prizes, "Id", "Id", moviePrize.PrizeId);
            return View(moviePrize);
        }

        // GET: MoviePrizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePrize = await _context.MoviePrizes
                .Include(m => m.Movie)
                .Include(m => m.Prize)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviePrize == null)
            {
                return NotFound();
            }

            return View(moviePrize);
        }

        // POST: MoviePrizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviePrize = await _context.MoviePrizes.FindAsync(id);
            _context.MoviePrizes.Remove(moviePrize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviePrizeExists(int id)
        {
            return _context.MoviePrizes.Any(e => e.Id == id);
        }
    }
}
