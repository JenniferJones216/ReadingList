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
    public class BookWishListsController : Controller
    {
        private readonly ReadingContext _context;

        public BookWishListsController(ReadingContext context)
        {
            _context = context;
        }

        // GET: BookWishLists
        public async Task<IActionResult> Index()
        {
            var readingContext = _context.BookWishLists.Include(b => b.Book).Include(b => b.WishList);
            return View(await readingContext.ToListAsync());
        }

        // GET: BookWishLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookWishList = await _context.BookWishLists
                .Include(b => b.Book)
                .Include(b => b.WishList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookWishList == null)
            {
                return NotFound();
            }

            return View(bookWishList);
        }

        // GET: BookWishLists/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id");
            return View();
        }

        // POST: BookWishLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,WishListId")] BookWishList bookWishList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookWishList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookWishList.BookId);
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id", bookWishList.WishListId);
            return View(bookWishList);
        }

        // GET: BookWishLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookWishList = await _context.BookWishLists.FindAsync(id);
            if (bookWishList == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookWishList.BookId);
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id", bookWishList.WishListId);
            return View(bookWishList);
        }

        // POST: BookWishLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,WishListId")] BookWishList bookWishList)
        {
            if (id != bookWishList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookWishList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookWishListExists(bookWishList.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookWishList.BookId);
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id", bookWishList.WishListId);
            return View(bookWishList);
        }

        // GET: BookWishLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookWishList = await _context.BookWishLists
                .Include(b => b.Book)
                .Include(b => b.WishList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookWishList == null)
            {
                return NotFound();
            }

            return View(bookWishList);
        }

        // POST: BookWishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookWishList = await _context.BookWishLists.FindAsync(id);
            _context.BookWishLists.Remove(bookWishList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookWishListExists(int id)
        {
            return _context.BookWishLists.Any(e => e.Id == id);
        }
    }
}
