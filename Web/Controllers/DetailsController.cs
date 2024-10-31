using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;

namespace Web.Controllers;

public class DetailsController : Controller
{
    private readonly BookContext _context;

    public DetailsController(BookContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Details(int? id)
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
}
