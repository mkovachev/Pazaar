using FluentValidation;
using Pazaar.Domain.Models;
using Pazaar.Domain.Models.Ads;

namespace Pazaar.Domain.Validations
{
    using static ModelConstants.Category;
    public abstract class CategoryValidator : AbstractValidator<Category>
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Please add a category name")
                .Length(TitleMinLength, TitleMaxLength)
                .WithMessage($"Name must be between {TitleMinLength} and {TitleMaxLength} characters");
        }
    }
}
