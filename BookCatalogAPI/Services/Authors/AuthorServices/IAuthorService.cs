using BookCatalogAPI.Requests.AuthorRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Services.Authors.AuthorServices;

public interface IAuthorService
{
    Task<AuthorViewModel> GetAuthorById(Guid id);
    Task<IEnumerable<AuthorViewModel>> GetAllAuthors();
    Task<bool> CreateAuthor(CreateAuthorRequest authorRequest);
    Task<bool> UpdateAuthor(UpdateAuthorRequest authorRequest);
    Task<bool> DeleteAuthor(Guid id);
}