using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.PublishingRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Mappers;

public class PublishingProfile : Profile
{
    public PublishingProfile()
    {
        CreateMap<CreatePublishingRequest, Publishing>();
        CreateMap<UpdatePublishingRequest, Publishing>();

        CreateMap<Publishing, PublishingViewModel>();
    }
}