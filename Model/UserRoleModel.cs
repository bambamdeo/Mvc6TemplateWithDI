using System;

namespace Model
{
    public class UserRoleModel
    {
        public UserRoleModel()
        {
            UserDetailsModel = new UserDetails();
        }

        public Int64 UserRoleId { get; set; }
        public string? Role { get; set; }
        public Int64? UserId { get; set; }

        public UserDetails UserDetailsModel { get; set; }
    }
}
