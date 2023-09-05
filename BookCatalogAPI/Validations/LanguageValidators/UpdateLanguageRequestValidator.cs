using BookCatalogAPI.Requests.LanguageRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.LanguageValidators;

public class UpdateLanguageRequestValidator : AbstractValidator<UpdateLanguageRequest>
{
    public UpdateLanguageRequestValidator()
    {
        RuleFor(l => l.Name).NotNull().NotEmpty().MaximumLength(50);
    }
}