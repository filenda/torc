using AutoMapper;
using BookLibraryApi.Features.Books.DTOs;
using BookLibraryApi.Features.Books.Services;
using MediatR;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UpdateBookCommandHandler(IBookService bookService, IMapper mapper, IMediator mediator)
    {
        _bookService = bookService;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var bookToUpdate = await _bookService.GetBookByIdAsync(request.BookId);

        if (bookToUpdate == null)
        {
            await _mediator.Publish(new BookNotFoundEvent(request.BookId));
            return null; // Or throw an exception
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