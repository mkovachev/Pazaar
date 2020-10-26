using FluentValidation;
using Pazaar.Domain.Model.Ad;
using Pazaar.Domain.Models;

namespace Pazaar.Domain.Validations
{
    using static ModelConstants.Category;
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(TitleMinLength)
                .WithMessage("Name must be at least 5 characters");

            RuleFor(c => c.Name)
                .MaximumLength(TitleMaxLength)
                .WithMessage("Name must be max 30 characters");
        }
    }
}
