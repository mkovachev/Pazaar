using Pazaar.Domain.Model.Customer;

namespace Pazaar.Domain.Factories.Customers
{
    internal class CustomerFactory : ICustomerFactory
    {
        private string name = default!;

        public Customer Build(string name) => this.WithName(name).Build();

        public Customer Build() => new Customer(this.name);

        public ICustomerFactory WithName(string name)
        {
            this.name = name;
            return this;
        }
    }
}