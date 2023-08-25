using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Services;
using BookCatalogAPI.Dtos;
using BookCatalogAPI.Requests.BookRequests;
using BookCatalogAPI.Responses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ValidationException = FluentValidation.ValidationException;

namespace BookCatalogAPI.Services.Books.BookServices;

public class BookService: IBookService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public BookService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<BookViewModel> GetBookById(Guid id)
    {
        var book = await _dbContext
            .Books
                .FirstOrDefaultAsync(b => b.Id == id);
        var bookViewModel = _mapper.Map<BookViewModel>(book);
        return bookViewModel;
    }

    public async Task<IEnumerable<BookViewModel>> GetAllBooks()
    {
        var books = await _dbContext.Books.ToListAsync();
        var bookViewModels = books
            .Select(
                book => _mapper
                    .Map<BookViewModel>(book))
            .ToList();
        return bookViewModels;
    }

    public async Task<bool> CreateBook(CreateBookRequest createBookRequest)
    {
        var book = _mapper.Map<Book>(createBookRequest) ?? throw new Exception("Book is not found");
        book.CreatedAt = DateTime.Now;
        await _dbContext.AddAsync(book);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateBook(UpdateBookRequest updateBookRequest)
    {
        var book = await _dbContext.Books
            .AsTracking()
            .FirstOrDefaultAsync(b => b.Id == updateBookRequest.Id) ?? throw new Exception("Data is not updated");
        _mapper.Map(updateBookRequest,book);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBook(Guid id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception("No deleted");
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}