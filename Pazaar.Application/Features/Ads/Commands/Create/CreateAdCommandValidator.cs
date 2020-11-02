using FluentValidation;

namespace Pazaar.Application.Features.Ads.Commands.Create
{
    public class CreateAdCommandValidator : AbstractValidator<CreateAdCommand>
    {
        public CreateAdCommandValidator()
        {
            Include(new AdCommandValidator<CreateAdCommand>());
        }
    }
}
