using BookCatalogAPI.Requests.BookRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.BookValidators;

public class CreateBookRequestValidator: AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(b => b.Name).NotNull().NotEmpty();
        RuleFor(b => b.CountPage).LessThanOrEqualTo(10000);
        RuleFor(b => b.YearOfPublication).LessThanOrEqualTo(DateTime.Now.Date);
    }
}