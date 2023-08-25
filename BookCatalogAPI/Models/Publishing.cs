namespace BookCatalogAPI.Models;

public class Publishing
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CityId { get; set; }

    public City City { get; set; } = new();
    
    public List<Subject> Subjects { get; set; } = new();

}