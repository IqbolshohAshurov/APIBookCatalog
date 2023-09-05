using BookCatalogAPI.Requests.BookRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.BookValidators;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(b => b.Name).NotNull().NotEmpty();
        RuleFor(b => b.CountPage).LessThanOrEqualTo(10000);
        RuleFor(b => b.YearOfPublication).LessThanOrEqualTo(DateTime.Now.Year.ToString());

        RuleFor(b => b.AuthorId).NotNull().NotEmpty();
        RuleFor(b => b.PuId).NotNull().NotEmpty();
        RuleFor(b => b.SuId).NotNull().NotEmpty();
        RuleFor(b => b.LanguageId).NotNull().NotEmpty();
    }
}