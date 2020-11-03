using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Customers.Queries.Details
{
    public class CustomerDetailsQuery : IRequest<CustomerDetailsOutputModel>
    {
        public int Id { get; set; }

        public class CustomerDetailsQueryHandler : IRequestHandler<CustomerDetailsQuery, CustomerDetailsOutputModel>
        {
            private readonly ICustomerRepository customerRepository;

            public CustomerDetailsQueryHandler(ICustomerRepository customerRepository)
                => this.customerRepository = customerRepository;

            public async Task<CustomerDetailsOutputModel> Handle(CustomerDetailsQuery request, CancellationToken cancellationToken)
                => await this.customerRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
