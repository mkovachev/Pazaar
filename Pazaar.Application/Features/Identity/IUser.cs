using Pazaar.Domain.Model.Customer;

namespace Pazaar.Application.Features.Identity
{
    public interface IUser
    {
        void BecomeCustomer(Customer customer);
    }
}
