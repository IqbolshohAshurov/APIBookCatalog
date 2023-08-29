namespace BookCatalogAPI.Models;

public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Status { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

}