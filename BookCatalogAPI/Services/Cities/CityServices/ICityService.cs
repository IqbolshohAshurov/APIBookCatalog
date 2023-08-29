using BookCatalogAPI.Requests.CityRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Services.Cities.CityServices;

public interface ICityService
{
    Task<CityViewModel> GetCityById(Guid id);
    Task<IEnumerable<CityViewModel>> GetAllCities();
    Task<bool> CreateCity(CreateCityRequest cityRequest);
    Task<bool> UpdateCity(UpdateCityRequest cityRequest);
    Task<bool> DeleteCity(Guid id);
}