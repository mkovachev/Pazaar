using Pazaar.Domain.Model.Customer;

namespace Pazaar.Application.Features.Identity
{
    public interface IDomainUser
    {
        void BecomeCustomer(Customer customer);
    }
}
