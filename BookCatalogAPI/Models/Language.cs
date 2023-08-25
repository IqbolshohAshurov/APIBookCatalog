namespace BookCatalogAPI.Models;

public class Language
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<Book> Books { get; set; }
    public List<BookLanguage> BookLanguages { get; set; }
}