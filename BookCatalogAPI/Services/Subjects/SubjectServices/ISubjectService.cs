using BookCatalogAPI.Requests.SubjectRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Services.Subjects.SubjectServices;

public interface ISubjectService
{
    Task<SubjectViewModel> GetSubjectById(Guid id);
    Task<IEnumerable<SubjectViewModel>> GetAllSubjects();
    Task<bool> CreateSubject(CreateSubjectRequest subjectRequest);
    Task<bool> UpdateSubject(UpdateSubjectRequest subjectRequest);
    Task<bool> DeleteSubject(Guid id);
}