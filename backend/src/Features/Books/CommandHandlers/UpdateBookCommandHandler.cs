using AutoMapper;
using BookLibraryApi.Features.Books.DTOs;
using BookLibraryApi.Features.Books.Services;
using MediatR;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var bookToUpdate = await _bookService.GetBookByIdAsync(request.BookId);

        if (bookToUpdate == null)
        {
            // throw new NotFoundException("Book not found");
            throw new Exception("Book not found");
        }

        bookToUpdate.Title = request.Title;
        bookToUpdate.FirstName = request.FirstName;
        bookToUpdate.LastName = request.LastName;
        bookToUpdate.TotalCopies = request.TotalCopies;
        bookToUpdate.CopiesInUse = request.CopiesInUse;
        bookToUpdate.Category = request.Category;
        bookToUpdate.ISBN = request.ISBN; 
        bookToUpdate.Type = request.Type;

        await _bookService.UpdateBookAsync(bookToUpdate);

        return _mapper.Map<BookDto>(bookToUpdate);
    }
}