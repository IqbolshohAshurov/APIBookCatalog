namespace BookCatalogAPI.Models;

public class BookLanguage
{
    public Guid Id { get; set; }

    public Guid BookId { get; set; }
    public Book Book { get; set; }
    
    public Guid LanguageId { get; set; }
    public Language Language { get; set; }
    
 }