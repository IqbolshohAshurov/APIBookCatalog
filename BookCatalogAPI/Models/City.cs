namespace BookCatalogAPI.Models;

public class City
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Publishing> Publishings { get; set; } = new List<Publishing>();

}