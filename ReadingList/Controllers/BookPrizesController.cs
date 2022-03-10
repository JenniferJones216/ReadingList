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
    public class BookPrizesController : Controller
    {
        private readonly ReadingContext _context;

        public BookPrizesController(ReadingContext context)
        {
            _context = context;
        }

        // GET: BookPrizes
        public async Task<IActionResult> Index()
        {
            var readingContext = _context.BookPrizes.Include(b => b.Book).Include(b => b.Prize);
            return View(await readingContext.ToListAsync());
        }

        // GET: BookPrizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPrize = await _context.BookPrizes
                .Include(b => b.Book)
                .Include(b => b.Prize)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookPrize == null)
            {
                return NotFound();
            }

            return View(bookPrize);
        }

        // GET: BookPrizes/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["PrizeId"] = new SelectList(_context.Prizes, "Id", "Id");
            return View();
        }

        // POST: BookPrizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,PrizeId")] BookPrize bookPrize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookPrize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookPrize.BookId);
            ViewData["PrizeId"] = new SelectList(_context.Prizes, "Id", "Id", bookPrize.PrizeId);
            return View(bookPrize);
        }

        // GET: BookPrizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPrize = await _context.BookPrizes.FindAsync(id);
            if (bookPrize == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookPrize.BookId);
            ViewData["PrizeId"] = new SelectList(_context.Prizes, "Id", "Id", bookPrize.PrizeId);
            return View(bookPrize);
        }

        // POST: BookPrizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,PrizeId")] BookPrize bookPrize)
        {
            if (id != bookPrize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPrize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPrizeExists(bookPrize.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookPrize.BookId);
            ViewData["PrizeId"] = new SelectList(_context.Prizes, "Id", "Id", bookPrize.PrizeId);
            return View(bookPrize);
        }

        // GET: BookPrizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPrize = await _context.BookPrizes
                .Include(b => b.Book)
                .Include(b => b.Prize)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookPrize == null)
            {
                return NotFound();
            }

            return View(bookPrize);
        }

        // POST: BookPrizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookPrize = await _context.BookPrizes.FindAsync(id);
            _context.BookPrizes.Remove(bookPrize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPrizeExists(int id)
        {
            return _context.BookPrizes.Any(e => e.Id == id);
        }
    }
}
