using FluentValidation;
using Pazaar.Domain.Model.Ad;

namespace Pazaar.Domain.Validations
{
    public class AdValidator : AbstractValidator<Ad>
    {
        public AdValidator()
        {
        }
    }
}
