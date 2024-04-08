using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookLibraryApi.Data;
using BookLibraryApi.Features.Books.Models;
using BookLibraryApi.Features.Books.DTOs;

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

        public async Task<PaginatedListDto<Book>> SearchBooksAsync(BookSearchOptions searchOptions)
        {
            IQueryable<Book> query = _dbContext.Books;

            if (!string.IsNullOrEmpty(searchOptions.Criteria.Title))
            {
                var searchQuery = searchOptions.Criteria.Title;
                query = query.Where(b => EF.Functions.ToTsVector("english", b.Title).Matches(EF.Functions.ToTsQuery("english", searchQuery)));
            }

            else if (!string.IsNullOrEmpty(searchOptions.Criteria.Author))
            {
                var searchQuery = searchOptions.Criteria.Author;
                query = query.Where(b => EF.Functions.ToTsVector("english", b.Author).Matches(EF.Functions.ToTsQuery("english", searchQuery)));
            }

            else if (!string.IsNullOrEmpty(searchOptions.Criteria.Category))
            {
                var searchQuery = searchOptions.Criteria.Category;
                query = query.Where(b => EF.Functions.ToTsVector("english", b.Category).Matches(EF.Functions.ToTsQuery("english", searchQuery)));
            }

            var totalItems = await query.CountAsync();
            var items = await query.Skip((searchOptions.Page - 1) * searchOptions.PageSize)
                                   .Take(searchOptions.PageSize)
                                   .ToListAsync();

            return new PaginatedListDto<Book>(items, totalItems, searchOptions.Page, searchOptions.PageSize);
        }
    }
}