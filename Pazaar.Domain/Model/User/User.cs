using Pazaar.Domain.Common;

namespace Pazaar.Domain.Model.User
{
    public class User : EntityAudit
    {
        internal User(string name, string number, string profileImage, string city)
        {
            this.Name = name;
            this.Phone = number;
            this.ProfileImage = profileImage;
            this.City = city;
        }

        internal User(string name)
        {
            this.Name = name;
            this.Phone = default!;
            this.ProfileImage = default!;
            this.City = default!;
        }


        public string Name { get; private set; }
        public Phone Phone { get; private set; }
        public string ProfileImage { get; private set; }
        public string City { get; private set; }

        public User UpdateName(string name)
        {
            this.Name = name;

            return this;
        }

        public User UpdatePhoneNumber(string number)
        {
            this.Phone = number;

            return this;
        }

        public User UpdateProfileImage(string profileImage)
        {
            this.ProfileImage = profileImage;

            return this;
        }

        public User UpdateCity(string city)
        {
            this.City = city;

            return this;
        }
    }
}