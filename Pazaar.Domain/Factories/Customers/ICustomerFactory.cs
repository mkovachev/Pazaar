using Pazaar.Domain.Model.Customer;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Factories.Customers
{
    public interface ICustomerFactory : IFactory<Customer>
    {
        ICustomerFactory WithName(string name);

        ICustomerFactory WithEmail(string email);

        ICustomerFactory WithPhoneNumber(string phoneNumber);

        ICustomerFactory WithCity(string city);

        ICustomerFactory WithProfileImage(string profileImage);

        ICustomerFactory WithAds(IReadOnlyCollection<Ad> ads);
    }
}
