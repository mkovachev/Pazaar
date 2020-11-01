using Pazaar.Domain.Model.Customer;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Factories.Customers
{
    internal class CustomerFactory : ICustomerFactory
    {
        private string name = default!;
        private string email = default!;
        private string city = default!;
        private string phoneNumber = default!;
        private string profileImage = default!;
        private IReadOnlyCollection<Ad> ads = new List<Ad>().AsReadOnly();

        public Customer Build() => new Customer(this.name, this.email);

        public Customer Build(string name, string email, string city, string phoneNumber, string profileImage, IReadOnlyCollection<Ad> ads)
            => this
                  .WithName(name)
                  .WithEmail(email)
                  .WithCity(city)
                  .WithPhoneNumber(phoneNumber)
                  .WithProfileImage(profileImage)
                  .WithAds(ads)
                  .Build();


        public ICustomerFactory WithName(string name)
        {
            this.name = name;
            return this;
        }
        public ICustomerFactory WithEmail(string email)
        {
            this.email = email;
            return this;
        }

        public ICustomerFactory WithCity(string city)
        {
            this.city = city;
            return this;
        }


        public ICustomerFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public ICustomerFactory WithProfileImage(string profileImage)
        {
            this.profileImage = profileImage;
            return this;
        }

        public ICustomerFactory WithAds(IReadOnlyCollection<Ad> ads)
        {
            this.ads = ads;
            return this;
        }
    }
}
