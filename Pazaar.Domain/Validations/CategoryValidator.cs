using FluentValidation;
using Pazaar.Domain.Models;

namespace Pazaar.Domain.Validations
{
    using static ModelConstants.Category;
    public abstract class CategoryValidator : AbstractValidator<Category>
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Please add category name")
                .Length(TitleMinLength, TitleMaxLength)
                .WithMessage($"Name must be between {TitleMinLength} and {TitleMaxLength} characters");
        }
    }
}
