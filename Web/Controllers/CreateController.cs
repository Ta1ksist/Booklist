using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web.Data;

namespace Web.Controllers;

public class CreateController : Controller
{
    private readonly BookContext _context;

    public CreateController(BookContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index ()
    {
        return View(await _context.Books.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Description,Author,Year")] Book book)
    {   
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
        
    }
}

