using Pazaar.Domain.Common;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Model.Users
{
    public class DomainUser : Entity
    {
        public DomainUser(string name, string email)
        {
            this.Name = name;
            this.Email = email;

        }
        public DomainUser(string name, string email, string phoneNumber, string city, string profileImage)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.ProfileImage = profileImage;
            this.City = city;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string ProfileImage { get; private set; } = default!;
        public IReadOnlyCollection<Ad> Ads => this.Ads.ToList().AsReadOnly();

        public DomainUser UpdateName(string name)
        {
            this.Name = name;

            return this;
        }

        public DomainUser UpdateEmail(string email)
        {
            this.Email = email;

            return this;
        }

        public DomainUser UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }
        public DomainUser UpdateCity(string city)
        {
            this.City = city;

            return this;
        }

        public DomainUser UpdateProfileImage(string profileImage)
        {
            this.ProfileImage = profileImage;

            return this;
        }
    }
}