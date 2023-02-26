using System;
using System.Collections.Generic;

namespace Model
{
    public class UserDetails
    {
        public UserDetails()
        {
            
        }

        public Int64 UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int UserType { get; set; }//1 for admin, 2 for other
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
