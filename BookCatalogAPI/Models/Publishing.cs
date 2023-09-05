namespace BookCatalogAPI.Models;

public class Publishing : BaseModel
{
    public string Name { get; set; }
    public Guid CityId { get; set; }

    public City City { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public ICollection<SubjectPublishing> SubjectPublishings { get; set; }= new List<SubjectPublishing>();

}