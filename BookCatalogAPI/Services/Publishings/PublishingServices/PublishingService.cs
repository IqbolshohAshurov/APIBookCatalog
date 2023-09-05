using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.PublishingRequests;
using BookCatalogAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI.Services.Publishings.PublishingServices;

public class PublishingService : IPublishingService
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
        var publishing = await _dbContext.Publishings
            .FirstOrDefaultAsync(p => p.Id == id);

        await _dbContext.Entry(publishing).Reference(p => p.City).LoadAsync();
        await _dbContext.Entry(publishing).Collection(p => p.Subjects).LoadAsync();
        await _dbContext.Entry(publishing).Collection(p => p.Books).LoadAsync();

        var publishingViewModel = _mapper.Map(publishing, new PublishingViewModel());

        var books = new List<string>();
        var subjects = new List<string>();
        foreach (var subject in publishing.Subjects)
        {
            subjects.Add(subject.Title);
        }

        foreach (var book in publishing.Books)
        {
            books.Add(book.Name);
        }

        publishingViewModel.BookNames = books;
        publishingViewModel.SubjectNames = subjects;

        return publishingViewModel;
    }

    public async Task<IEnumerable<PublishingViewModel>> GetAllPublishings()
    {
        var publishings = await _dbContext.Publishings
            .Include(p => p.City)
            .Include(p => p.Subjects)
            .Include(p => p.Books)
            .ToListAsync();

        var publishingViewModels = publishings
            .Select(p =>
            {
                var view = _mapper.Map(p, new PublishingViewModel());

                var books = new List<string>();
                var subjects = new List<string>();

                foreach (var subject in p.Subjects)
                {
                    subjects.Add(subject.Title);
                }

                foreach (var book in p.Books)
                {
                    books.Add(book.Name);
                }

                view.BookNames = books;
                view.SubjectNames = subjects;

                return view;
            }).ToList();

        return publishingViewModels;
    }

    public async Task<bool> CreatePublishing(CreatePublishingRequest publishingRequest)
    {
        var publishing = _mapper.Map<Publishing>(publishingRequest);
        publishing.CreatedAt = DateTime.UtcNow;
        _dbContext.Publishings.Add(publishing);

        var subject = await _dbContext.Subjects
            .FirstOrDefaultAsync(s => s.Id == publishingRequest.SubjectId);

        publishing.SubjectPublishings.Add(new SubjectPublishing()
        {
            SubjectId = publishingRequest.SubjectId,
            PublishingId = publishing.Id
        });

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatePublishing(UpdatePublishingRequest publishingRequest)
    {
        var publishing = await _dbContext.Publishings
            .FirstOrDefaultAsync(p => p.Id == publishingRequest.Id);
        _mapper.Map(publishingRequest, publishing);
        _dbContext.SubjectPublishings.Add(new SubjectPublishing()
        {
            SubjectId = publishingRequest.SubjectId,
            PublishingId = publishing.Id
        });

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