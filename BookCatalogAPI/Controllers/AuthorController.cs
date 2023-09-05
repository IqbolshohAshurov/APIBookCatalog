using BookCatalogAPI.Requests.AuthorRequests;
using BookCatalogAPI.Services.Authors.AuthorServices;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IValidator<CreateAuthorRequest> _validatorCreateAuthorRequest;
    private readonly IValidator<UpdateAuthorRequest> _validatorUpdateAuthorRequest;

    public AuthorController(IAuthorService authorService,
        IValidator<CreateAuthorRequest> validatorCreateAuthorRequest,
        IValidator<UpdateAuthorRequest> validatorUpdateAuthorRequest)
    {
        _authorService = authorService;
        _validatorCreateAuthorRequest = validatorCreateAuthorRequest;
        _validatorUpdateAuthorRequest = validatorUpdateAuthorRequest;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _authorService.GetAuthorById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _authorService.GetAllAuthors());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorRequest authorRequest)
    {
        var result = await _validatorCreateAuthorRequest.ValidateAsync(authorRequest);
        if (!result.IsValid) return Ok(result.Errors.Select(x => x.ErrorMessage).ToList());
        return Ok(await _authorService.CreateAuthor(authorRequest));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAuthorRequest authorRequest)
    {
        var result = await _validatorUpdateAuthorRequest.ValidateAsync(authorRequest);

        if (!result.IsValid) return Ok(result.Errors.Select(a => a.ErrorMessage).ToList());
        return Ok(await _authorService.UpdateAuthor(authorRequest));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _authorService.DeleteAuthor(id));
    }
}