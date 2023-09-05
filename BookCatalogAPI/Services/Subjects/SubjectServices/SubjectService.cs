using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.SubjectRequests;
using BookCatalogAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI.Services.Subjects.SubjectServices;

public class SubjectService : ISubjectService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public SubjectService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<SubjectViewModel> GetSubjectById(Guid id)
    {
        var subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        var subjectViewModel = _mapper.Map(subject, new SubjectViewModel());
        return subjectViewModel;
    }

    public async Task<IEnumerable<SubjectViewModel>> GetAllSubjects()
    {
        var subjects = await _dbContext.Subjects.ToListAsync();

        var subjectViewModels = subjects.Select(s => _mapper.Map(s, new SubjectViewModel())).ToList();

        return subjectViewModels;
    }

    public async Task<bool> CreateSubject(CreateSubjectRequest subjectRequest)
    {
        var subject = _mapper.Map(subjectRequest, new Subject());

        await _dbContext.Subjects.AddAsync(subject);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateSubject(UpdateSubjectRequest subjectRequest)
    {
        var subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.Id == subjectRequest.Id);
        _mapper.Map(subjectRequest, subject);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteSubject(Guid id)
    {
        var subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        _dbContext.Subjects.Remove(subject);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}