using BookCatalogAPI.Requests.PublishingRequests;
using BookCatalogAPI.Services.Publishings.PublishingServices;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishingController: ControllerBase
{
    private readonly IPublishingService _publishingService;

    public PublishingController(IPublishingService publishingService)
    {
        _publishingService = publishingService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _publishingService.GetPublishingById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _publishingService.GetAllPublishings());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePublishingRequest publishingRequest)
    {
        return Ok(await _publishingService.CreatePublishing(publishingRequest));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdatePublishingRequest publishingRequest)
    {
        return Ok(await _publishingService.UpdatePublishing(publishingRequest));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _publishingService.DeletePublishing(id));
    }

}