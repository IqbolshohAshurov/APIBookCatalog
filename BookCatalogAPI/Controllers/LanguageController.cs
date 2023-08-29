using BookCatalogAPI.Requests.LanguageRequests;
using BookCatalogAPI.Services.Languages.LanguageServices;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageController: ControllerBase
{
    private readonly ILanguageService _languageService;

    public LanguageController(ILanguageService languageService)
    {
        _languageService = languageService;
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
        return Ok(await _languageService.CreateLanguage(languageRequest));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateLanguageRequest languageRequest)
    {
        return Ok(await _languageService.UpdateLanguage(languageRequest));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _languageService.DeleteLanguage(id));
    }
}