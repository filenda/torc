using Microsoft.EntityFrameworkCore;
using BookLibraryApi.Features.Books.Models; // Import your book model

namespace BookLibraryApi.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } // DbSet for book entity

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Configure entity mappings or relationships here if needed
      // For example:
      // modelBuilder.Entity<Book>().ToTable("Books");
      // modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
    }
  }
}
