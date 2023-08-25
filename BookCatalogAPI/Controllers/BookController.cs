using BookCatalogAPI.Services;
using BookCatalogAPI.Dtos;
using BookCatalogAPI.Requests.BookRequests;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BookController: ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IValidator<CreateBookRequest> _validator;
    private readonly IValidator<UpdateBookRequest> _validatorWithId;
    public BookController(IBookService bookService, IValidator<CreateBookRequest> validator, IValidator<UpdateBookRequest> validatorWithId)
    {
        _validator = validator;
        _validatorWithId = validatorWithId;
        _bookService = bookService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _bookService.GetBookById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _bookService.GetAllBooks());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest createBookRequest)
    {
        var result = await _validator.ValidateAsync(createBookRequest);
        if (!result.IsValid)
        {
            return Ok(result.Errors.Select(x => x.ErrorMessage).ToList());
        }
        return Ok(await _bookService.CreateBook(createBookRequest));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBookRequest updateBook)
    {
        var result = await _validatorWithId.ValidateAsync(updateBook);
        if (!result.IsValid)
        {
            return Ok(result.Errors.Select(x => x.ErrorMessage).ToList());
        }
        return Ok(await _bookService.UpdateBook(updateBook));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _bookService.DeleteBook(id));
    }
}