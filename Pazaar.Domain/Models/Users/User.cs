using Pazaar.Domain.Common;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Model.Users
{
    public class User : AuditEntity
    {
        public User(string name, string email, string phoneNumber, string city, string profileImage)
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

        public User UpdateName(string name)
        {
            this.Name = name;

            return this;
        }

        public User UpdateEmail(string email)
        {
            this.Email = email;

            return this;
        }

        public User UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }
        public User UpdateCity(string city)
        {
            this.City = city;

            return this;
        }

        public User UpdateProfileImage(string profileImage)
        {
            this.ProfileImage = profileImage;

            return this;
        }
    }
}