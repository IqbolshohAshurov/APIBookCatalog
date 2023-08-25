namespace BookCatalogAPI.Models;

public class Subject
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    
    public Guid PublishingId { get; set; }
    
    public Publishing Publishing { get; set; }
    
}