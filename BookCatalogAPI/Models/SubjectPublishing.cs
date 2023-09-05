namespace BookCatalogAPI.Models;

public class SubjectPublishing
{
    public Guid Id { get; set; }
    public Guid PublishingId { get; set; }
    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; }
    public Publishing Publishing { get; set; }
}