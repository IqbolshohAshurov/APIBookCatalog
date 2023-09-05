using BookCatalogAPI.Requests.LanguageRequests;
using BookCatalogAPI.Services.Languages.LanguageServices;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageController : ControllerBase
{
    private readonly IValidator<CreateLanguageRequest> _createLanguageRequestValidator;
    private readonly ILanguageService _languageService;
    private readonly IValidator<UpdateLanguageRequest> _updateLanguageRequestValidator;

    public LanguageController(ILanguageService languageService,
        IValidator<CreateLanguageRequest> createLanguageRequestValidator,
        IValidator<UpdateLanguageRequest> updateLanguageRequestValidator)
    {
        _languageService = languageService;
        _createLanguageRequestValidator = createLanguageRequestValidator;
        _updateLanguageRequestValidator = updateLanguageRequestValidator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _languageService.GetLanguageById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _languageService.GetAllLanguages());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLanguageRequest languageRequest)
    {
        var result = await _createLanguageRequestValidator.ValidateAsync(languageRequest);

        if (!result.IsValid)
            return Ok(result.Errors.Select(e => e.ErrorMessage.ToList()));
        return Ok(await _languageService.CreateLanguage(languageRequest));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateLanguageRequest languageRequest)
    {
        var result = await _updateLanguageRequestValidator.ValidateAsync(languageRequest);

        if (!result.IsValid)
            return Ok(result.Errors.Select(e => e.ErrorMessage.ToList()));
        return Ok(await _languageService.UpdateLanguage(languageRequest));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _languageService.DeleteLanguage(id));
    }
}