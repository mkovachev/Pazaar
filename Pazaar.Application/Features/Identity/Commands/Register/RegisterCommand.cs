using MediatR;
using Pazaar.Application.Common;
using Pazaar.Application.Features.Customers;
using Pazaar.Application.Identity;
using Pazaar.Domain.Factories.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Identity.Commands.Register
{
    public class RegisterCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;
    }

    public class CreateUserCommandHandler : IRequestHandler<RegisterCommand, Result>
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
        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await this.identity.Register(request);

            if (!result.Succeeded)
            {
                return result.Errors;
            }

            var user = result.Data;

            var customer = this.customerFactory
                            .WithEmail(request.Email)
                            .Build();

            user.BecomeCustomer(customer);

            await this.customerRepository.Save(customer, cancellationToken);

            return result;
        }
    }
}
