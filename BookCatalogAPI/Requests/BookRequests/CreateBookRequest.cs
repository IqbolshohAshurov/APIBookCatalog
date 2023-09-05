namespace BookCatalogAPI.Requests.BookRequests;

public class CreateBookRequest
{
    public string Name { get; set; }
    public int CountPage { get; set; }
    public string YearOfPublication { get; set; }
    public string Isbn { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public byte Edition { get; set; }

    public Guid SuId { get; set; }
    public Guid PuId { get; set; }
    public Guid AuthorId { get; set; }
    public Guid LanguageId { get; set; }
}