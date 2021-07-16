namespace CarRentingSystem.Data
{
    public class DataConstants
    {
        public class Car
        {
            public const int BrandMinLength = 2;
            public const int BrandMaxLength = 20;
            public const int ModelMinLength = 2;
            public const int ModelMaxLength = 30;
            public const int DescriptionMinLength = 10;
            public const int YearMinValue = 2000;
            public const int YearMaxValue = 2050;
        }

        public class Category
        {
            public const int NameMaxLength = 25;
        }

        public class Dealer
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 25;
            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 30;
        }
    }
}
