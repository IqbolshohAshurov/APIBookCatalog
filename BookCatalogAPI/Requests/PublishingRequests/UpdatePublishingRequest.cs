namespace BookCatalogAPI.Requests.PublishingRequests;

public class UpdatePublishingRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid CityId { get; set; }

   // public Guid BookId { get; set; }

    public Guid SubjectId { get; set; }
}