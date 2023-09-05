namespace BookCatalogAPI.Models;

public class Book : BaseModel
{
    public string Name { get; set; }
    public int CountPage { get; set; }
    public string? YearOfPublication { get; set; }
    public string? Isbn { get; set; }
    public string? Description { get; set; }
    public string? Photo { get; set; }
    public byte Edition { get; set; }

    public Guid SubjectId { get; set; }
    public Guid PublishingId { get; set; }

    public Subject Subject { get; set; }
    public Publishing Publishing { get; set; }
    public ICollection<Author> Authors { get; set; } = new List<Author>();
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public ICollection<Language> Languages { get; set; } = new List<Language>();
    public ICollection<BookLanguage> BookLanguages { get; set; } = new List<BookLanguage>();
}