using FluentValidation;
using Pazaar.Domain.Model.User;
using Pazaar.Domain.Models;

namespace Pazaar.Domain.Validations
{
    using static ModelConstants.Phone;
    public class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone.Number)
                .Matches(ValidePhoneNumber)
                .WithMessage("Phone number must start with a '+' and contain only digits afterwards.");

        }
    }
}
