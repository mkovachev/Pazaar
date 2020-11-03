using Pazaar.Application.Features.Customers.Queries;
using Pazaar.Application.Features.Customers.Queries.Details;
using Pazaar.Application.Interfaces;
using Pazaar.Domain.Model.Customer;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> Find(string userId, CancellationToken cancellationToken = default);

        Task<CustomerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<bool> HasAd(int id, int adId, CancellationToken cancellationToken = default);
    }
}
