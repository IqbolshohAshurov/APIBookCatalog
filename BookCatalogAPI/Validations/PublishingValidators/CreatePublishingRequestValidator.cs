using BookCatalogAPI.Requests.PublishingRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.PublishingValidators;

public class CreatePublishingRequestValidator: AbstractValidator<CreatePublishingRequest>
{
    public CreatePublishingRequestValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty();
    }
}