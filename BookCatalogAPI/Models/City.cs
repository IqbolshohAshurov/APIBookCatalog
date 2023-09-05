namespace BookCatalogAPI.Models;

public class City : BaseModel
{
    public string Name { get; set; }

    public ICollection<Publishing> Publishings { get; set; } = new List<Publishing>();
}