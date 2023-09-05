using BookCatalogAPI.Requests.PublishingRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.PublishingValidators;

public class UpdatePublishingRequestValidator : AbstractValidator<UpdatePublishingRequest>
{
    public UpdatePublishingRequestValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty();

        RuleFor(p => p.CityId).NotNull().NotEmpty();

       // RuleFor(p => p.BookId).NotNull().NotEmpty();

        RuleFor(p => p.SubjectId).NotNull().NotEmpty();
    }
}