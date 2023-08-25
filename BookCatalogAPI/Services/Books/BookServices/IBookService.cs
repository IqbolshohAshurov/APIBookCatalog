using BookCatalogAPI.Models;
using BookCatalogAPI.Dtos;
using BookCatalogAPI.Requests.BookRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Services;

public interface IBookService
{
    Task<BookViewModel> GetBookById(Guid id);
    Task<IEnumerable<BookViewModel>> GetAllBooks();
    Task<bool> CreateBook(CreateBookRequest createBookRequest);
    Task<bool> UpdateBook(UpdateBookRequest updateBookRequest);
    Task<bool> DeleteBook(Guid id);
    
}