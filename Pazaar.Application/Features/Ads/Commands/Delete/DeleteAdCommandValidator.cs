using FluentValidation;

namespace Pazaar.Application.Features.Ads.Commands.Delete
{
    public class DeleteAdCommandValidator : AbstractValidator<DeleteAdCommand>
    {
        public DeleteAdCommandValidator()
        {
            Include(new AdCommandValidator<DeleteAdCommand>());
        }
    }
}
