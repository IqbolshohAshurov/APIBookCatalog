using BookCatalogAPI.Requests.PublishingRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Services.Publishings.PublishingServices;

public interface IPublishingService
{
    Task<PublishingViewModel> GetPublishingById(Guid id);
    Task<IEnumerable<PublishingViewModel>> GetAllPublishings();
    Task<bool> CreatePublishing(CreatePublishingRequest publishingRequest);
    Task<bool> UpdatePublishing(UpdatePublishingRequest publishingRequest);
    Task<bool> DeletePublishing(Guid id);
}