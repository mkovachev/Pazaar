using FakeItEasy;
using Pazaar.Domain.Model.Customer;
using System;

namespace Pazaar.Domain.Models.Customers
{
    public class CustomersFakes
    {
        public class CategoryDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Customer);

            public object? Create(Type type) => new Customer("John");

            public Priority Priority => Priority.Default;
        }
    }
}
