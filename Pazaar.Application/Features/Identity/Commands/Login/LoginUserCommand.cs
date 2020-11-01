using MediatR;
using Pazaar.Application.Common;
using Pazaar.Application.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Identity.Commands.Login
{
    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public string Token { get; } = default!;

        public class LoginCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;

            public LoginCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }
            public async Task<Result<LoginOutputModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                return user.Token;
            }
        }
    }
}