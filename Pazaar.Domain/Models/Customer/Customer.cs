using Pazaar.Domain.Common;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Model.Customer
{
    public class Customer : AuditableEntity, IAggregateRoot
    {
        internal Customer(string name, string email, string phoneNumber, string city, string profileImage)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.ProfileImage = profileImage;
            this.City = city;
        }

        internal Customer(string name, string email)
        {
            this.Name = name;
            this.Email = email;

        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string ProfileImage { get; private set; } = default!;
        public IList<Ad> Ads { get; } = new List<Ad>().AsReadOnly();

        public Customer UpdateName(string name)
        {
            this.Name = name;

            return this;
        }

        public Customer UpdateEmail(string email)
        {
            this.Email = email;

            return this;
        }

        public Customer UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }
        public Customer UpdateCity(string city)
        {
            this.City = city;

            return this;
        }

        public Customer UpdateProfileImage(string profileImage)
        {
            this.ProfileImage = profileImage;

            return this;
        }

        public void AddAd(Ad ad)
        {
            var adTitle = ad.Title;

            if (this.Ads.Any(ad => ad.Title == adTitle))
            {
                return;
            }

            this.Ads.Add(ad);
        }

        public void DeleteCategory(Ad ad)
        {
            var adTitle = ad.Title;

            if (this.Ads.Any(ad => ad.Title == adTitle))
            {
                this.Ads.Remove(ad);
            }
        }
    }
}