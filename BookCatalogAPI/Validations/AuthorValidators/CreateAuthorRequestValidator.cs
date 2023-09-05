using BookCatalogAPI.Requests.AuthorRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.AuthorValidators;

public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>

{
    public CreateAuthorRequestValidator()
    {
        RuleFor(a => a.FirstName).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(a => a.LastName).NotEmpty().NotNull().MaximumLength(50);
    }
}