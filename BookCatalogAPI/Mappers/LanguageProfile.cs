using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.LanguageRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Mappers;

public class LanguageProfile: Profile
{
    public LanguageProfile()
    {
        CreateMap<CreateLanguageRequest, Language>();
        CreateMap<UpdateLanguageRequest, Language>();

        CreateMap<Language, LanguageViewModel>();
    }

}