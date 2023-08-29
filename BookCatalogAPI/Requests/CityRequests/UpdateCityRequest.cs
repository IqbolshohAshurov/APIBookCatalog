namespace BookCatalogAPI.Requests.CityRequests;

public class UpdateCityRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}