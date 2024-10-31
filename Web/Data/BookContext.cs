using System;
using Microsoft.Build.Construction;
using Microsoft.EntityFrameworkCore;

namespace Web.Data;

public class BookContext : DbContext
{
    public BookContext (DbContextOptions<BookContext> options)
        :base(options)
        {
            Database.EnsureCreated();
        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source = Booklist.db");
    }
    public DbSet<Book> Books { get; set; }
}
