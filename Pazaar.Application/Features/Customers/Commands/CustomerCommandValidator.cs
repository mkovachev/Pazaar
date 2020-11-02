using FluentValidation;
using Pazaar.Domain.Models;

namespace Pazaar.Application.Features.Customers.Commands
{
    using static ModelConstants.Customer;
    public class CustomerCommandValidator<TCommand> : AbstractValidator<CustomerCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        protected void ValidateName()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Please add your name")
                .Length(NameMinLength, NameMaxLength)
                .WithMessage($"Name must be between {NameMinLength} and {NameMaxLength} characters");
        }
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidatePhoneNumber()
        {
            RuleFor(u => u.PhoneNumber)
                .Matches(ValidPhoneNumber)
                .WithMessage("Phone number must start with '+' sign, followed by digits only.");
        }

        protected void ValidateCity()
        {
            RuleFor(u => u.City)
                .Length(CityMinLength, CityMaxLength)
                .WithMessage($"City must be between {CityMinLength} and {CityMaxLength} characters");
        }
    }
}
