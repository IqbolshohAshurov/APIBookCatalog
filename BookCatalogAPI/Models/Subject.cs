namespace BookCatalogAPI.Models;

public class Subject : BaseModel
{
    public ICollection<Book> Books = new List<Book>();
    public string Title { get; set; }

    public ICollection<Publishing> Publishings { get; set; } = new List<Publishing>();
    public ICollection<SubjectPublishing> SubjectPublishings { get; set; } = new List<SubjectPublishing>();

}