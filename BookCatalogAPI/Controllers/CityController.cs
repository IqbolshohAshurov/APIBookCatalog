using BookCatalogAPI.Requests.CityRequests;
using BookCatalogAPI.Services.Cities.CityServices;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
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
        return Ok(await _cityService.CreateCity(cityRequest));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCityRequest cityRequest)
    {
        return Ok(await _cityService.UpdateCity(cityRequest));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _cityService.DeleteCity(id));
    }

}