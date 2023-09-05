namespace BookCatalogAPI.Responses;

public class BookViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int CountPage { get; set; }
    public string? YearOfPublication { get; set; }
    public string? Isbn { get; set; }
    public string? Description { get; set; }
    public string? Photo { get; set; }
    public byte Edition { get; set; }


    // public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }

    // public Guid PublishingId { get; set; }
    public string PublishingName { get; set; }

    // public Guid AuthorId { get; set; }
    public ICollection<string> AuthorFullNames { get; set; }

    // public Guid LanguageId { get; set; }
    public ICollection<string> LanguageNames { get; set; }
}