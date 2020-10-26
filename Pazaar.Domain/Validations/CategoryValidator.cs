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
                .NotNull().WithMessage("Please add category name")
                .Length(TitleMinLength, TitleMaxLength)
                .WithMessage("Name must be between 5 and 30 characters");
        }
    }
}
