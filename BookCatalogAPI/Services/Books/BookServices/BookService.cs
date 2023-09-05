using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.BookRequests;
using BookCatalogAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI.Services.Books.BookServices;

public class BookService : IBookService
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
        // var a = _dbContext.Books.Include(b => b.Authors).Include(b => b.Languages).ToList();

        // var book = await _dbContext
        //     .Books
        //         .FirstOrDefaultAsync(b => b.Id == id);
        //
        // var author = await _dbContext.BookAuthors.FirstOrDefaultAsync(ba => ba.BookId == book.Id);
        // var language = await _dbContext.BookLanguages.FirstOrDefaultAsync(bl => bl.BookId == book.Id);
        //
        // var bookViewModel = _mapper.Map<BookViewModel>(book);
        //
        // bookViewModel.AuthorId = author.AuthorId;
        // bookViewModel.LanguageId = language.LanguageId;

        var bookDetail = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        await _dbContext.Entry(bookDetail).Collection(b => b.Authors).LoadAsync();
        await _dbContext.Entry(bookDetail).Collection(b => b.Languages).LoadAsync();
        await _dbContext.Entry(bookDetail).Reference(b => b.Publishing).LoadAsync();
        await _dbContext.Entry(bookDetail).Reference(b => b.Subject).LoadAsync();

        // .AsQueryable()
        // .Where(b => b.Id == id)
        // .Include(b => b.Authors)
        // .Include(b => b.Languages)
        // .Include(b => b.Publishing)
        // .Include(b => b.Subject)
        // .First();

        var view = _mapper.Map<BookViewModel>(bookDetail);
        // var author = bookDetail.Authors.First();
        // var language = bookDetail.Languages.First();
        // view.AuthorId = author.Id;
        // view.AuthorFullName = author.FirstName + author.LastName;
        // view.LanguageId = language.Id;
        // view.LanguageName = language.Name;
        var authors = new List<string>();
        var languages = new List<string>();

        foreach (var author in bookDetail.Authors)
            authors.Add(author.FirstName + " " + author.LastName + ",");

        foreach (var language in bookDetail.Languages)
            languages.Add(language.Name + ",");

        view.LanguageNames = languages;
        view.AuthorFullNames = authors;

        return view;
    }

    public async Task<IEnumerable<BookViewModel>> GetAllBooks()
    {
        var books = await _dbContext.Books.ToListAsync();

        var bookDetails = await _dbContext.Books.AsQueryable()
            .Include(b => b.Authors)
            .Include(b => b.Languages)
            .Include(b => b.Publishing)
            .Include(b => b.Subject)
            .ToListAsync();


        var bookViewModels = bookDetails.Select(book =>
        {
            var view = _mapper.Map<BookViewModel>(book);

            // view.PublishingName = book.Publishing.Name;
            // view.SubjectName = book.Subject.Title;

            var authors = new List<string>();
            var languages = new List<string>();

            foreach (var author in book.Authors)
            {
                authors.Add(author.FirstName + " " + author.LastName);
            }

            foreach (var language in book.Languages)
            {
                languages.Add(language.Name);
            }

            view.LanguageNames = languages;
            view.AuthorFullNames = authors;

            return view;
        }).ToList();

        return bookViewModels;
    }

    public async Task<bool> CreateBook(CreateBookRequest createBookRequest)
    {
        var book = _mapper.Map<Book>(createBookRequest);

        var author = await _dbContext.Authors
            .FirstOrDefaultAsync(a => a.Id == createBookRequest.AuthorId);
        var language = await _dbContext.Languages
            .FirstOrDefaultAsync(l => l.Id == createBookRequest.LanguageId);

        //var author = await CheckAuthorExits(createBookRequest.AuthorId);
        await _dbContext.AddAsync(book);

        await _dbContext.BookLanguages.AddAsync(new BookLanguage
        {
            LanguageId = language.Id,
            BookId = book.Id
        });
        await _dbContext.BookAuthors.AddAsync(new BookAuthor
        {
            AuthorId = author.Id,
            BookId = book.Id
        });

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateBook(UpdateBookRequest updateBookRequest)
    {
        var book = await _dbContext.Books
                       .AsTracking()
                       .FirstOrDefaultAsync(b => b.Id == updateBookRequest.Id)
                   ?? throw new Exception("Data is not updated");

        _mapper.Map(updateBookRequest, book);

        var author = await _dbContext.Authors
                         .FirstOrDefaultAsync(a => a.Id == updateBookRequest.AuthorId) ??
                     throw new Exception("Author is not found");
        var language = await _dbContext.Languages
                           .FirstOrDefaultAsync(l => l.Id == updateBookRequest.LanguageId) ??
                       throw new Exception("Language is not found");

         _dbContext.BookAuthors.Add(new BookAuthor
        {
            AuthorId = author.Id,
            BookId = book.Id
        });

        _dbContext.BookLanguages.Add(new BookLanguage
        {
            LanguageId = language.Id,
            BookId = book.Id
        });


        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBook(Guid id)
    {
        var book = await _dbContext.Books
                       .FirstOrDefaultAsync(b => b.Id == id)
                   ?? throw new Exception("No deleted");

        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Author> CheckAuthorExits(Guid authorId)
    {
        return await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId) ??
               throw new Exception("Author not found");
    }
}