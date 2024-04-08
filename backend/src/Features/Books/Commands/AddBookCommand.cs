using BookLibraryApi.Features.Books.DTOs;
using MediatR;

public class AddBookCommand : IRequest<BookDto>
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ISBN { get; set; }
    public string Type { get; set; }
    public string Category { get; set; }
    public int TotalCopies { get; set; }
    public int CopiesInUse { get; set; }
}