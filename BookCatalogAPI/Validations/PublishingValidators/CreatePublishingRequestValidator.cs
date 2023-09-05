using BookCatalogAPI.Requests.PublishingRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.PublishingValidators;

public class CreatePublishingRequestValidator : AbstractValidator<CreatePublishingRequest>
{
    public CreatePublishingRequestValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty();

        RuleFor(p => p.CityId).NotNull().NotEmpty();

       // RuleFor(p => p.BookId).NotNull().NotEmpty();

        RuleFor(p => p.SubjectId).NotNull().NotEmpty();
    }
}