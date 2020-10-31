namespace Pazaar.Domain.Models
{
    public class ModelConstants
    {
        public class Customer
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;

            public const int PhoneNumberMinLength = 5;
            public const int PhoneNumberMaxLength = 20;
            public const string ValidPhoneNumber = @"\+[0-9]*";

            public const int CityMinLength = 3;
            public const int CityMaxLength = 30;

            public const int ProfileImageUrlMinLength = 4;
            public const int ProfileImageUrlMaxLength = 2048;
        }

        public class Ad
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 70;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 200;

            public const decimal MinPrice = 0.1M;
            public const decimal MaxPrice = 500000000.0M;
        }

        public class Category
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 30;
        }

        public class Galley
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 30;
            public const int ImageUrlMinLength = 4;
            public const int ImageUrlMaxLength = 2048;
        }

        public class Image
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 30;
            public const int ImageUrlMinLength = 4;
            public const int ImageUrlMaxLength = 2048;
        }
    }
}
