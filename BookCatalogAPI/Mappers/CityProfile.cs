using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.CityRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Mappers;

public class CityProfile: Profile
{
    public CityProfile()
    {
        CreateMap<CreateCityRequest, City>();
        CreateMap<UpdateCityRequest, City>();

        CreateMap<City, CityViewModel>();
    }
}