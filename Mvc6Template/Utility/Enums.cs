using System.ComponentModel;

namespace Utility
{
    public class Enums
    {
        public enum YesOrNo
        {
            Yes,
            No,
        }

        public enum YesNoNa
        {
            Yes,
            No,
            Na
        }

        public enum UserRoles
        {
            [Description("Admin")]
            Admin = 1,
            [Description("Employee")]
            Employee = 2,
        }
        public enum Gender
        {
            [Description("Male")]
            Male = 1,
            [Description("Female")]
            Female = 2,
        }

        public static class ConstUserRoles
        {
            public const string Admin = "Admin";
            public const string Employee = "Employee";
        }

        public enum Status
        {
            [Description("Draft")]
            Draft = 1,
            [Description("Submitted")]
            Submitted = 2,
        }

    }
}
