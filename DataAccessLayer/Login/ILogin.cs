using DataTransferObject.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Login
{
    public interface ILogin
    {
        void SaveUserLoginDetails(LoginDTO loginDTO);
        bool AuthenticateUser(LoginDTO loginDTO);
    }
}
