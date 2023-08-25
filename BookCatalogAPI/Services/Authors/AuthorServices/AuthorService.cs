using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.AuthorRequests;
using BookCatalogAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI.Services.Authors.AuthorServices;

public class AuthorService: IAuthorService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public AuthorService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<AuthorViewModel> GetAuthorById(Guid id)
    {
        var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id) ?? throw new Exception("Not found author");
        var authorViewModel = _mapper.Map<AuthorViewModel>(author);
        return authorViewModel;
    }

    public async Task<IEnumerable<AuthorViewModel>> GetAllAuthors()
    {
        var authors = await _dbContext.Authors.ToListAsync();
        var authorViewModel = authors
            .Select(a =>
                _mapper.Map<AuthorViewModel>(a))
            .ToList();
        return authorViewModel;
    }

    public async Task<bool> CreateAuthor(CreateAuthorRequest authorRequest)
    {
        var author = _mapper.Map<Author>(authorRequest);
        await _dbContext.Authors.AddAsync(author);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAuthor(UpdateAuthorRequest authorRequest)
    {
        var author = await _dbContext.Authors.AsTracking().FirstOrDefaultAsync(a => a.Id == authorRequest.Id) ?? throw new Exception("Not found incorrectly data");
        _mapper.Map(authorRequest, author);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAuthor(Guid id)
    {
        var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id) ?? throw new Exception("Author is not deleted");
        _dbContext.Authors.Remove(author);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}