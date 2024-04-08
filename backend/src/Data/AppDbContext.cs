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
      modelBuilder.Entity<Book>().ToTable("books");
      modelBuilder.Entity<Book>().Property(b => b.Id).HasColumnName("book_id").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.Title).HasColumnName("title").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.Author).HasColumnName("full_name").HasComputedColumnSql("full_name").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.FirstName).HasColumnName("first_name").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.LastName).HasColumnName("last_name").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.Category).HasColumnName("category").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.ISBN).HasColumnName("isbn").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.Type).HasColumnName("type").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.CopiesInUse).HasColumnName("copies_in_use").IsRequired();
      modelBuilder.Entity<Book>().Property(b => b.TotalCopies).HasColumnName("total_copies").IsRequired();
    }
  }
}
