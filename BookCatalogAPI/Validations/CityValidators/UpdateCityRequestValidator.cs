using BookCatalogAPI.Requests.CityRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.CityValidators;

public class UpdateCityRequestValidator: AbstractValidator<UpdateCityRequest>
{
    public UpdateCityRequestValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty();
    }
}