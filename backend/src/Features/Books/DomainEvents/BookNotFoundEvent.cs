using MediatR;

public class BookNotFoundEvent: INotification
{
    public int BookId { get; }

    public BookNotFoundEvent(int bookId)
    {
        BookId = bookId;
    }
}
