using BookCatalogAPI.Requests.BookRequests;
using FluentValidation;

namespace BookCatalogAPI.Validations.BookValidators;

public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookRequestValidator()
    {
        RuleFor(b => b.Name).NotNull().NotEmpty();
        RuleFor(b => b.CountPage).LessThanOrEqualTo(10000);
        RuleFor(b => b.YearOfPublication).LessThanOrEqualTo(DateTime.Today.Year.ToString());
        RuleFor(b => b.AuthorId).NotNull().NotEmpty();
        RuleFor(b => b.PublishingId).NotNull().NotEmpty();
        RuleFor(b => b.SubjectId).NotNull().NotEmpty();
        RuleFor(b => b.LanguageId).NotNull().NotEmpty();
    }
}