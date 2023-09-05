using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.AuthorRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Mappers;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<CreateAuthorRequest, Author>();
        CreateMap<UpdateAuthorRequest, Author>();
        CreateMap<Author, AuthorViewModel>();
    }
}