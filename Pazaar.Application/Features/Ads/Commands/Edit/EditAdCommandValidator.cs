using FluentValidation;

namespace Pazaar.Application.Features.Ads.Commands.Edit
{
    public class EditAdCommandValidator : AbstractValidator<EditAdCommand>
    {
        public EditAdCommandValidator()
        {
            Include(new AdCommandValidator<EditAdCommand>());
        }
    }
}
