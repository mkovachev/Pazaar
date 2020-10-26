namespace Pazaar.Domain.Models
{
    public class ModelConstants
    {
        public class User
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 30;
        }

        public class Phone
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string ValidePhoneNumber = @"\+[0-9]*";
        }

        public class Ad
        {
            public const int MinTitelLength = 10;
            public const int MaxTitelLength = 70;
        }

        public class Category
        {
            public const int MinTitelLength = 5;
            public const int MaxTitelLength = 30;
        }

        public class Image
        {
            public const int MinUrlLength = 4;
            public const int MaxUrlLength = 2048;
        }
    }
}
