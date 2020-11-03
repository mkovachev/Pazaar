using Pazaar.Domain.Model.Customer;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Factories.Customers
{
    internal class CustomerFactory : ICustomerFactory
    {
        private string name = default!;

        //private readonly List<Ad> ads;

        //public CustomerFactory(string name)
        //{
        //    this.name = name;
        //    this.ads = new List<Ad>();
        //}

        public Customer Build() => new Customer(this.name);

        //public IReadOnlyCollection<Ad> Ads => this.ads.AsReadOnly();

        public ICustomerFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

    }
}
