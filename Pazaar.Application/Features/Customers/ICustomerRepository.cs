using Pazaar.Domain.Model.Customer;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Customers
{
    public interface ICustomerRepository //: IRepository<Customer>
    {
        Task<Customer> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetDealerId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasAd(int dealerId, int adId, CancellationToken cancellationToken = default);

        //Task<CustomerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        //Task<CustomerOutputModel> GetDetailsByCarId(int adId, CancellationToken cancellationToken = default);
    }
}
