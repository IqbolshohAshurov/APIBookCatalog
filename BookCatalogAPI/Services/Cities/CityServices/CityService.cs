using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.CityRequests;
using BookCatalogAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI.Services.Cities.CityServices;

public class CityService : ICityService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CityService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CityViewModel> GetCityById(Guid id)
    {
        var city = await _dbContext
                       .Cities
                       .AsNoTracking()
                       .FirstOrDefaultAsync(c => c.Id == id)
                   ?? throw new Exception("Not Found");

        var cityViewModel = _mapper.Map(city, new CityViewModel());
        return cityViewModel;
    }

    public async Task<IEnumerable<CityViewModel>> GetAllCities()
    {
        var cities = await _dbContext.Cities.ToListAsync();
        var cityViewModels = cities
            .Select(c => _mapper
                .Map(c, new CityViewModel()))
            .ToList();

        return cityViewModels;
    }

    public async Task<bool> CreateCity(CreateCityRequest cityRequest)
    {
        var city = _mapper
            .Map(cityRequest, new City()) ?? throw new Exception("City is not added");
        await _dbContext.Cities.AddAsync(city);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateCity(UpdateCityRequest cityRequest)
    {
        var city = await _dbContext
            .Cities
            .FirstOrDefaultAsync(c => c.Id == cityRequest.Id) ?? throw new Exception("City is not updated");
        _mapper.Map(cityRequest, city);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCity(Guid id)
    {
        var city = await _dbContext
                       .Cities
                       .FirstOrDefaultAsync(c => c.Id == id) ??
                   throw new Exception("City is not deleted");
        _dbContext.Cities.Remove(city);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}