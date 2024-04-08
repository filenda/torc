using AutoMapper;
using BookLibraryApi.Features.Books.DTOs;
using BookLibraryApi.Features.Books.Models;
using BookLibraryApi.Features.Books.Services;
using MediatR;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDto>
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public AddBookCommandHandler(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            FirstName = request.FirstName,
            LastName = request.LastName,
            TotalCopies = request.TotalCopies,
            CopiesInUse = request.CopiesInUse,
            Category = request.Category,
            ISBN = request.ISBN,
            Type = request.Type
        };

        await _bookService.AddBookAsync(book);
        return _mapper.Map<BookDto>(book);
    }
}