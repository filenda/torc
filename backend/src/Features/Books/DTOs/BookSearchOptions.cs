namespace BookLibraryApi.Features.Books.DTOs
{
    public class BookSearchOptions
    {
        public BookSearchCriteria Criteria { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}