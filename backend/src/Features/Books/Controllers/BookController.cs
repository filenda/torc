using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BookLibraryApi.Features.Books.DTOs;
using BookLibraryApi.Features.Books.Models;
using BookLibraryApi.Features.Books.Services;

namespace BookLibraryApi.Features.Books.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<BookDto>>> SearchBooks(
            [FromQuery] string? title,
            [FromQuery] string? author,
            [FromQuery] string? category,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10) // Default page and page size values
        {
            var searchCriteria = new BookSearchCriteria
            {
                Title = title,
                Author = author,
                Category = category
            };

            var searchOptions = new BookSearchOptions
            {
                Criteria = searchCriteria,
                Page = page,
                PageSize = pageSize
            };

            var paginatedBooks = await _bookService.SearchBooksAsync(searchOptions);
            var bookDtos = _mapper.Map<List<BookDto>>(paginatedBooks.Items);

            var paginationInfo = new
            {
                TotalItems = paginatedBooks.TotalItems,
                TotalPages = paginatedBooks.TotalPages,
                CurrentPage = paginatedBooks.CurrentPage,
                PageSize = paginatedBooks.PageSize
            };

            return Ok(new { Books = bookDtos, Pagination = paginationInfo });
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, _mapper.Map<BookDto>(book));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }

            var existingBook = await _bookService.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, existingBook);
            await _bookService.UpdateBookAsync(existingBook);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
