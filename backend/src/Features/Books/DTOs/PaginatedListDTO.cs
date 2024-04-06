namespace BookLibraryApi.Features.Books.DTOs
{
  public class PaginatedListDto<T>
  {
    public List<T> Items { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public PaginatedListDto(List<T> items, int totalItems, int currentPage, int pageSize)
    {
      Items = items;
      TotalItems = totalItems;
      TotalPages = (int)System.Math.Ceiling(totalItems / (double)pageSize);
      CurrentPage = currentPage;
      PageSize = pageSize;
    }
  }
}
