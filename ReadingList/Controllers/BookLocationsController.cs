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
    public class BookLocationsController : Controller
    {
        private readonly ReadingContext _context;

        public BookLocationsController(ReadingContext context)
        {
            _context = context;
        }

        // GET: BookLocations
        public async Task<IActionResult> Index()
        {
            var readingContext = _context.BookLocations.Include(b => b.Book).Include(b => b.Location);
            return View(await readingContext.ToListAsync());
        }

        // GET: BookLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLocation = await _context.BookLocations
                .Include(b => b.Book)
                .Include(b => b.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookLocation == null)
            {
                return NotFound();
            }

            return View(bookLocation);
        }

        // GET: BookLocations/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: BookLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,LocationId,Audiobook,URL")] BookLocation bookLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookLocation.BookId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", bookLocation.LocationId);
            return View(bookLocation);
        }

        // GET: BookLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLocation = await _context.BookLocations.FindAsync(id);
            if (bookLocation == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookLocation.BookId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", bookLocation.LocationId);
            return View(bookLocation);
        }

        // POST: BookLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,LocationId,Audiobook,URL")] BookLocation bookLocation)
        {
            if (id != bookLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookLocationExists(bookLocation.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookLocation.BookId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", bookLocation.LocationId);
            return View(bookLocation);
        }

        // GET: BookLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLocation = await _context.BookLocations
                .Include(b => b.Book)
                .Include(b => b.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookLocation == null)
            {
                return NotFound();
            }

            return View(bookLocation);
        }

        // POST: BookLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookLocation = await _context.BookLocations.FindAsync(id);
            _context.BookLocations.Remove(bookLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookLocationExists(int id)
        {
            return _context.BookLocations.Any(e => e.Id == id);
        }
    }
}
