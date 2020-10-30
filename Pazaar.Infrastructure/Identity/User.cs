using Microsoft.AspNetCore.Identity;

namespace Pazaar.Infrastructure.Identity
{
    public class User : IdentityUser//, IUser
    {
        //internal User(string email)
        //    : base(email)
        //    => this.Email = email;

        //public Customer? Customer { get; private set; }

        //public void BecomeCustomer(Customer customer)
        //{
        //    if (this.Customer != null)
        //    {
        //        throw new InvalidCustomerException($"User '{this.UserName}' is already a customer.");
        //    }

        //    this.Customer = customer;
        //}
    }
}