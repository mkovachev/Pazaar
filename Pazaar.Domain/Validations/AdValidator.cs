using FluentValidation;
using Pazaar.Domain.Model.Ad;
using Pazaar.Domain.Models;

namespace Pazaar.Domain.Validations
{
    using static ModelConstants.Ad;
    public abstract class AdValidator : AbstractValidator<Ad>
    {
        public void ValidateTitle()
        {
            RuleFor(ad => ad.Title)
                .NotNull().WithMessage("Please add a title")
                .Length(TitleMinLength, TitleMaxLength)
                .WithMessage($"Name must be between {TitleMinLength} and {TitleMaxLength} characters");
        }
    }
}
