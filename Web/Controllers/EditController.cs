using System;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Data;
using Microsoft.EntityFrameworkCore;


namespace Web.Controllers;

public class EditController : Controller
{

    private readonly BookContext _context;

    public EditController(BookContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index ()
    {
        return View(await _context.Books.ToListAsync());
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
         return NotFound();
        }
    return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,Year")] Book book)
    {
        if (id != book.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {   
            try
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(book.Id))
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
        return View(book);
    }

    private bool BookExists(int id)
    {
        throw new NotImplementedException();
    }
}
