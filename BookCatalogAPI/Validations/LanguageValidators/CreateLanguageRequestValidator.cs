using BookCatalogAPI.Requests.LanguageRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.LanguageValidators;

public class CreateLanguageRequestValidator : AbstractValidator<CreateLanguageRequest>
{
    public CreateLanguageRequestValidator()
    {
        RuleFor(l => l.Name).NotNull().NotEmpty().MaximumLength(50);
    }
}