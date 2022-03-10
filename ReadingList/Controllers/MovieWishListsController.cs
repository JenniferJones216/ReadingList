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
    public class MovieWishListsController : Controller
    {
        private readonly ReadingContext _context;

        public MovieWishListsController(ReadingContext context)
        {
            _context = context;
        }

        // GET: MovieWishLists
        public async Task<IActionResult> Index()
        {
            var readingContext = _context.MovieWishLists.Include(m => m.Movie).Include(m => m.WishList);
            return View(await readingContext.ToListAsync());
        }

        // GET: MovieWishLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieWishList = await _context.MovieWishLists
                .Include(m => m.Movie)
                .Include(m => m.WishList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieWishList == null)
            {
                return NotFound();
            }

            return View(movieWishList);
        }

        // GET: MovieWishLists/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id");
            return View();
        }

        // POST: MovieWishLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,WishListId")] MovieWishList movieWishList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieWishList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieWishList.MovieId);
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id", movieWishList.WishListId);
            return View(movieWishList);
        }

        // GET: MovieWishLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieWishList = await _context.MovieWishLists.FindAsync(id);
            if (movieWishList == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieWishList.MovieId);
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id", movieWishList.WishListId);
            return View(movieWishList);
        }

        // POST: MovieWishLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,WishListId")] MovieWishList movieWishList)
        {
            if (id != movieWishList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieWishList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieWishListExists(movieWishList.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieWishList.MovieId);
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id", movieWishList.WishListId);
            return View(movieWishList);
        }

        // GET: MovieWishLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieWishList = await _context.MovieWishLists
                .Include(m => m.Movie)
                .Include(m => m.WishList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieWishList == null)
            {
                return NotFound();
            }

            return View(movieWishList);
        }

        // POST: MovieWishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieWishList = await _context.MovieWishLists.FindAsync(id);
            _context.MovieWishLists.Remove(movieWishList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieWishListExists(int id)
        {
            return _context.MovieWishLists.Any(e => e.Id == id);
        }
    }
}
