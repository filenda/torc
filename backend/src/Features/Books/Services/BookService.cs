using System.Collections.Generic;
using System.Threading.Tasks;
using BookLibraryApi.Features.Books.DTOs;
using BookLibraryApi.Features.Books.Models;
using BookLibraryApi.Features.Books.Repositories;

namespace BookLibraryApi.Features.Books.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<PaginatedListDto<Book>> SearchBooksAsync(BookSearchOptions searchOptions)
        {
            return _bookRepository.SearchBooksAsync(searchOptions);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddBookAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}
