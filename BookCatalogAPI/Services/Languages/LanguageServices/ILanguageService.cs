using BookCatalogAPI.Requests.LanguageRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Services.Languages.LanguageServices;

public interface ILanguageService
{
    Task<LanguageViewModel> GetLanguageById(Guid id);
    Task<IEnumerable<LanguageViewModel>> GetAllLanguages();
    Task<bool> CreateLanguage(CreateLanguageRequest languageRequest);
    Task<bool> UpdateLanguage(UpdateLanguageRequest languageRequest);
    Task<bool> DeleteLanguage(Guid id);
}