using MediatR;
using Pazaar.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Identity.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Result>
    {
        public string CurrentPassword { get; set; } = default!;

        public string NewPassword { get; set; } = default!;

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
        {
            private readonly IUser user;
            private readonly IIdentityService identity;

            public ChangePasswordCommandHandler(
                IUser User,
                IIdentityService identity)
            {
                this.User = user;
                this.identity = identity;
            }

            public async Task<Result> Handle(
                ChangePasswordCommand request,
                CancellationToken cancellationToken)
                => await this.identity.ChangePassword(new ChangePasswordInputModel(
                    this.User.UserId,
                    request.CurrentPassword,
                    request.NewPassword));
        }
    }
}