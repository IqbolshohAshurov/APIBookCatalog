namespace BookCatalogAPI.Requests.BookRequests;

public class UpdateBookRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int CountPage { get; set; }
    public DateTime? YearOfPublication { get; set; }
    public string? Isbn { get; set; }
    public string? Description { get; set; }
    public string? Photo { get; set; }
    public byte Edition { get; set; }
    public Guid SubjectId { get; set; }
    public Guid PublishingId { get; set; }
}