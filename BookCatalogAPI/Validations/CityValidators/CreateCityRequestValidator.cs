using BookCatalogAPI.Requests.CityRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.CityValidators;

public class CreateCityRequestValidator: AbstractValidator<CreateCityRequest>
{
    public CreateCityRequestValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty().MaximumLength(50);
    }
}