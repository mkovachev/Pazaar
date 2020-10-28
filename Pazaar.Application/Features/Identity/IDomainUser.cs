using Pazaar.Domain.Model.Users;

namespace Pazaar.Application.Features.Identity
{
    public interface IDomainUser
    {
        void BecomeCustomer(Customer customer);
    }
}
