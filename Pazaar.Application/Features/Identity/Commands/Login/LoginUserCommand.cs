using MediatR;
using Pazaar.Application.Common;
using Pazaar.Application.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Identity.Commands.Login
{
    public class LoginUserCommand : UserInputModel, IRequest<Result>
    {
        public string Token { get; } = default!;

        public class LoginCommandHandler : IRequestHandler<LoginUserCommand, Result>
        {
            private readonly IIdentity identity;

            public LoginCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }
            public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                return result.Succeeded
                            ? Result.Success
                            : Result.Failure(result.Errors);
            }
        }
    }
}