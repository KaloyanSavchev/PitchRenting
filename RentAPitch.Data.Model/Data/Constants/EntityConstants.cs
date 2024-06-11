namespace PitchRentingSystem.Web.Data.Constants
{
    public class EntityConstants
    {
        public const string DefaultPassword = "123456";

        public class PitchConstants
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 5;
            public const int AddressMaxLength = 150;
            public const int AddressMinLength = 10;
            public const int DescriptionMaxLenth = 500;
            public const int DescriptionMinLenth = 50;
        }

        public class CategoryConstants
        {
            public const int NameMaxLength = 50;
        }

        public class AgentConstants
        {
            
            public const int PhoneNumberMaxLength = 15;
        }
        public class AgentNumber
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
