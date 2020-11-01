using MediatR;
using Pazaar.Application.Common;
using Pazaar.Application.Features.Customers;
using Pazaar.Application.Identity;
using Pazaar.Domain.Factories.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Identity.Commands.Register
{
    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IIdentity identity;
        private readonly ICustomerFactory customerFactory;
        private readonly ICustomerRepository customerRepository;

        public CreateUserCommandHandler(
            IIdentity identity,
            ICustomerFactory customerFactory,
            ICustomerRepository customerRepository)
        {
            this.identity = identity;
            this.customerFactory = customerFactory;
            this.customerRepository = customerRepository;
        }
        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Result<IUser> result = (Result<IUser>)await this.identity.Register(request);

            if (!result.Succeeded)
            {
                return result.Errors;
            }

            var user = result.Data;

            var customer = this.customerFactory
                                        .WithName(request.Name)
                                        .WithEmail(request.Email)
                                        .Build();

            user.BecomeCustomer(customer);

            await this.customerRepository.Save(customer, cancellationToken);

            return result;
        }
    }
}
