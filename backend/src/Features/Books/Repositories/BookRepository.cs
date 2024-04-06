using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookLibraryApi.Data;
using BookLibraryApi.Features.Books.Models;

namespace BookLibraryApi.Features.Books.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
