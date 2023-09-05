using BookCatalogAPI.Requests.SubjectRequests;
using BookCatalogAPI.Services.Subjects.SubjectServices;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _subjectService.GetSubjectById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _subjectService.GetAllSubjects());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSubjectRequest subjectRequest)
    {
        return Ok(await _subjectService.CreateSubject(subjectRequest));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateSubjectRequest subjectRequest)
    {
        return Ok(await _subjectService.UpdateSubject(subjectRequest));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _subjectService.DeleteSubject(id));
    }
}