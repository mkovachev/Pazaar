using Pazaar.Domain.Common;
using Pazaar.Domain.Exceptions;
using Pazaar.Domain.Models;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Model.Customer
{
    using static ModelConstants.Customer;
    public class Customer : AuditableEntity, IAggregateRoot
    {
        private readonly HashSet<Ad> ads;

        internal Customer(string name)
        {
            this.ValidateName(name);

            this.Name = name;
            this.PhoneNumber = default!;
            this.ProfileImage = default!;
            this.City = default!;
            this.ads = new HashSet<Ad>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string City { get; private set; }
        public string ProfileImage { get; private set; }
        public IReadOnlyCollection<Ad> Ads => this.ads.ToList().AsReadOnly();

        public void AddAd(Ad ad) => this.ads.Add(ad);
        public void DeleteAd(Ad ad)
        {
            if (this.ads.Any(a => a.Title == ad.Title))
            {
                this.ads.Remove(ad);
            }
        }

        public Customer UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }
        public Customer UpdatePhoneNumber(string phoneNumber)
        {
            ValidatePhoneNumber(phoneNumber);
            this.PhoneNumber = phoneNumber;

            return this;
        }
        public Customer UpdateCity(string city)
        {
            this.ValidateCity(city);
            this.City = city;

            return this;
        }
        public Customer UpdateProfileImage(string profileImage)
        {
            ValidateProfileImage(profileImage);
            this.ProfileImage = profileImage;

            return this;
        }

        private void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidCustomerException>(name, NameMinLength, NameMaxLength);
        }
        private void ValidatePhoneNumber(string phoneNumber)
        {
            Guard.ForStringLength<InvalidCustomerException>(phoneNumber, PhoneNumberMinLength, PhoneNumberMaxLength);
        }
        private void ValidateCity(string city)
        {
            Guard.ForStringLength<InvalidCustomerException>(city, CityMinLength, CityMaxLength);
        }
        private void ValidateProfileImage(string profileImage)
        {
            Guard.ForValidUrl<InvalidCustomerException>(profileImage);
        }
    }
}