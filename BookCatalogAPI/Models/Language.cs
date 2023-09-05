namespace BookCatalogAPI.Models;

public class Language : BaseModel
{
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
    public ICollection<BookLanguage> BookLanguages { get; set; } = new List<BookLanguage>();
}