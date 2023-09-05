using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.LanguageRequests;
using BookCatalogAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI.Services.Languages.LanguageServices;

public class LanguageService : ILanguageService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public LanguageService(IMapper mapper, ApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<LanguageViewModel> GetLanguageById(Guid id)
    {
        var language = await _dbContext
                           .Languages
                           .FirstOrDefaultAsync(l => l.Id == id)
                       ?? throw new Exception("Not found language");
        var languageViewModel = _mapper.Map(language, new LanguageViewModel());
        return languageViewModel;
    }

    public async Task<IEnumerable<LanguageViewModel>> GetAllLanguages()
    {
        var languages = await _dbContext.Languages.ToListAsync();
        var languageViewModels = languages
            .Select(l => _mapper.Map(l, new LanguageViewModel()))
            .ToList();
        return languageViewModels;
    }

    public async Task<bool> CreateLanguage(CreateLanguageRequest languageRequest)
    {
        var language = _mapper.Map(languageRequest, new Language());
        await _dbContext.Languages.AddAsync(language);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateLanguage(UpdateLanguageRequest languageRequest)
    {
        var language = await _dbContext
            .Languages
            .FirstOrDefaultAsync(l => l.Id == languageRequest.Id);

        _mapper.Map(languageRequest, language);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteLanguage(Guid id)
    {
        var language = await _dbContext
            .Languages
            .FirstOrDefaultAsync(l => l.Id == id) ?? throw new Exception("Language is not deleted");
        _dbContext.Languages.Remove(language);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}