using Pazaar.Domain.Common;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Model.Customer
{
    public class Customer : AuditableEntity, IAggregateRoot
    {
        private readonly HashSet<Ad> ads;

        internal Customer(string name, string email, string phoneNumber, string city, string profileImage)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.ProfileImage = profileImage;
            this.City = city;

            this.ads = new HashSet<Ad>();
        }

        internal Customer(string name, string email)
        {
            this.Name = name;
            this.Email = email;

            this.ads = new HashSet<Ad>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string ProfileImage { get; private set; } = default!;
        public IReadOnlyCollection<Ad> Ads => this.ads.ToList().AsReadOnly();

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

            if (this.ads.Any(ad => ad.Title == adTitle))
            {
                return;
            }

            this.ads.Add(ad);
        }

        public void DeleteCategory(Ad ad)
        {
            var adTitle = ad.Title;

            if (this.ads.Any(ad => ad.Title == adTitle))
            {
                this.ads.Remove(ad);
            }
        }
    }
}