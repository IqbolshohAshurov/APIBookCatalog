namespace BookCatalogAPI.Requests.SubjectRequests;

public class CreateSubjectRequest
{
    public string Title { get; set; }
    public Guid PublishingId { get; set; }
}