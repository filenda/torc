using System.Collections.Generic;
using System.Threading.Tasks;
using BookLibraryApi.Features.Books.Models;

namespace BookLibraryApi.Features.Books.Repositories
{
  public interface IBookRepository
  {
    Task<List<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
  }
}
