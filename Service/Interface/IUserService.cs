using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IUserService
    {
        UserDetails AuthenticateUser(string email, string password);
        UserDetails AddUserDetails(UserDetails userDetailsModel);
        UserDetails EditUserDetails(UserDetails userDetailsModel);
        List<UserDetails> GetUserDetailList();      

    }

}
