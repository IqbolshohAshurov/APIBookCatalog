using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.PublishingRequests;
using BookCatalogAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI.Services.Publishings.PublishingServices;

public class PublishingService: IPublishingService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public PublishingService(IMapper mapper, ApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<PublishingViewModel> GetPublishingById(Guid id)
    {
        var publishing = await _dbContext
            .Publishings
            .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Not founded");

        var publishinngViewModel = _mapper.Map(publishing, new PublishingViewModel());
        return publishinngViewModel;
    }

    public async Task<IEnumerable<PublishingViewModel>> GetAllPublishings()
    {
        var publishings = await _dbContext.Publishings.ToListAsync();
        var publishingViewModels = publishings
            .Select(p => _mapper
                .Map(p, new PublishingViewModel()));
        return publishingViewModels;
    }

    public async Task<bool> CreatePublishing(CreatePublishingRequest publishingRequest)
    {
        var publishing = _mapper.Map<Publishing>(publishingRequest);

        await _dbContext.Publishings.AddAsync(publishing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatePublishing(UpdatePublishingRequest publishingRequest)
    {
        var publishing = await _dbContext.Publishings.FirstOrDefaultAsync(p => p.Id == publishingRequest.Id);
        _mapper.Map(publishingRequest, publishing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePublishing(Guid id)
    {
        var publishing = await _dbContext.Publishings.FirstOrDefaultAsync(p => p.Id == id);
        _dbContext.Publishings.Remove(publishing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

}