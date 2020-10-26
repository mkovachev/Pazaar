using FluentValidation;
using Pazaar.Domain.Model.User;
using Pazaar.Domain.Models;

namespace Pazaar.Domain.Validations
{
    using static ModelConstants.User;
    public class UserValidator<T> : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotNull().WithMessage("Please add your name");

            RuleFor(user => user.Name)
                .MinimumLength(MinNameLength)
                .WithMessage("Name must be at least 2 characters");

            RuleFor(user => user.Name)
                .MaximumLength(MaxNameLength)
                .WithMessage("Name must be max 30 characters");

            RuleFor(user => user.Phone).SetValidator(new PhoneValidator());
        }
    }
}
