using FluentValidation;
using Pazaar.Domain.Models;
using Pazaar.Domain.Models.Ads;

namespace Pazaar.Application.Validations
{
    using static ModelConstants.Category;
    public abstract class CategoryValidator : AbstractValidator<Category>
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please add a category name")
                .Length(NameMinLength, NameMaxLength)
                .WithMessage($"Name must be between {NameMinLength} and {NameMaxLength} characters");
        }
    }
}
