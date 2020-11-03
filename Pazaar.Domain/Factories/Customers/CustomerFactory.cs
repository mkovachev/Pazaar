using Pazaar.Domain.Model.Customer;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Factories.Customers
{
    internal class CustomerFactory : ICustomerFactory
    {
        private readonly string name = default!;

        private readonly List<Ad> ads;

        public CustomerFactory()
        {
            this.ads = new List<Ad>();
        }

        public Customer Build() => new Customer(name);

        public IReadOnlyCollection<Ad> Ads => this.ads.AsReadOnly();

    }
}
