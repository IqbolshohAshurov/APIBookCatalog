using BookCatalogAPI.Models;

namespace BookCatalogAPI.Responses;

public class PublishingViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }


   // public Guid CityId { get; set; }
    public string CityName { get; set; }


   // public Guid BookId { get; set; }
    public ICollection<string> BookNames { get; set; }


   // public Guid SubjectId { get; set; }
    public ICollection<string> SubjectNames { get; set; }
}