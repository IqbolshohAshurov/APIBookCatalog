using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.SubjectRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Mappers;

public class SubjectProfile: Profile
{
    public SubjectProfile()
    {
        CreateMap<CreateSubjectRequest, Subject>();
        CreateMap<UpdateSubjectRequest, Subject>();

        CreateMap<Subject, SubjectViewModel>();
    }
}