using MediatR;
using Pazaar.Application.Common;
using System.Threading;
using System.Threading.Tasks;
using Pazaar.Application.Features.Customers;

namespace Pazaar.Application.Features.Identity.Commands.Login
{
    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentityService identity;
            private readonly ICustomerRepository customerRepository;

            public LoginUserCommandHandler(
                IIdentityService identity,
                ICustomerRepository customerRepository)
            {
                this.identity = identity;
                this.customerRepository = customerRepository;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                var dealerId = await this.customerRepository.GetDealerId(user.UserId, cancellationToken);

                return new LoginOutputModel(user.Token, dealerId);
            }
        }
    }
}
