using BookCatalogAPI.Requests.SubjectRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.SubjectValidators;

public class CreateSubjectRequestValidator : AbstractValidator<CreateSubjectRequest>
{
    public CreateSubjectRequestValidator()
    {
        RuleFor(s => s.Title).NotNull().NotEmpty();
    }
}