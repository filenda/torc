namespace BookLibraryApi.Features.Books.Models
{
  public class Book
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Type { get; set; }
    public string Category { get; set; }
    public int TotalCopies { get; set; }
    public int CopiesInUse { get; set; }
  }
}