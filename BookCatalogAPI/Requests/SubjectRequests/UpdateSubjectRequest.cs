namespace BookCatalogAPI.Requests.SubjectRequests;

public class UpdateSubjectRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid PublishingId { get; set; }
}