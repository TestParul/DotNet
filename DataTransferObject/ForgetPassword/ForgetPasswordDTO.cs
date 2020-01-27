using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject.ForgetPassword
{
    public class ForgetPasswordDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }

    }
}
