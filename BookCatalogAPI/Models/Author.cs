namespace BookCatalogAPI.Models;

public class Author : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}