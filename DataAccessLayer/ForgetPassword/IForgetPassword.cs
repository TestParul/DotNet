using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject.ForgetPassword;

namespace DataAccessLayer.ForgetPassword
{
    public interface IForgetPassword
    {
        bool ForgetPasswordAuthentication(string userName);

        void SaveForgetPasswordPage(ForgetPasswordDTO forgetPasswordDTO);
    }
}
