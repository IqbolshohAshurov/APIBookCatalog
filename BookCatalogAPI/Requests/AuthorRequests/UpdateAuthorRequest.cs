namespace BookCatalogAPI.Requests.AuthorRequests;

public class UpdateAuthorRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}