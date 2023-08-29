using BookCatalogAPI.Requests.SubjectRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.SubjectValidators;

public class UpdateSubjectRequestValidator: AbstractValidator<UpdateSubjectRequest>
{
    public UpdateSubjectRequestValidator()
    {
        RuleFor(s => s.Title).NotNull().NotEmpty();
    }
}