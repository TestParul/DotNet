using DataAccessLayer.Login;
using DataTransferObject.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Login
{
    public class LoginModel
    {
        private readonly ILogin ilogin;
        public LoginModel(ILogin login)
        {
            ilogin = login;
        }

        public void saveUserLoginData(LoginDTO loginDTO) {
            ilogin.SaveUserLoginDetails(loginDTO);
        }

        public bool validateUser(LoginDTO loginDTO ) {
            bool checkUserExists = ilogin.AuthenticateUser(loginDTO);
            return checkUserExists;
        }
    }
}
