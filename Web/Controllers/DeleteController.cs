using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;

namespace Web.Controllers;

public class DeleteController : Controller
{
    private readonly BookContext _context;

    public DeleteController(BookContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index ()
    {
        return View(await _context.Books.ToListAsync());
    }

    public async Task<IActionResult> Delete(int? id)
    {

        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books
            .FirstOrDefaultAsync(m => m.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, bool notUsed)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _ = new Book { Id = book.Id };
            _context.Entry(book).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
