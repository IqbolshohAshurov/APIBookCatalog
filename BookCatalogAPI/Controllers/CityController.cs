using BookCatalogAPI.Requests.CityRequests;
using BookCatalogAPI.Services.Cities.CityServices;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;
    private readonly IValidator<CreateCityRequest> _createCityRequestValidator;
    private readonly IValidator<UpdateCityRequest> _updateCityRequestValidator;

    public CityController(ICityService cityService, IValidator<CreateCityRequest> createCityRequestValidator,
        IValidator<UpdateCityRequest> updateCityRequestValidator)
    {
        _cityService = cityService;
        _createCityRequestValidator = createCityRequestValidator;
        _updateCityRequestValidator = updateCityRequestValidator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _cityService.GetCityById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cityService.GetAllCities());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCityRequest cityRequest)
    {
        var result = await _createCityRequestValidator.ValidateAsync(cityRequest);
        if (!result.IsValid) return Ok(result.Errors.Select(e => e.ErrorMessage.ToList()));
        return Ok(await _cityService.CreateCity(cityRequest));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCityRequest cityRequest)
    {
        var result = await _updateCityRequestValidator.ValidateAsync(cityRequest);

        if (!result.IsValid) return Ok(result.Errors.Select(e => e.ErrorMessage.ToList()));
        return Ok(await _cityService.UpdateCity(cityRequest));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _cityService.DeleteCity(id));
    }
}