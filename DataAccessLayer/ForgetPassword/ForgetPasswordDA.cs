using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using DataTransferObject.ForgetPassword;

namespace DataAccessLayer.ForgetPassword
{
    public class ForgetPasswordDA : IForgetPassword
    {
        public readonly ForgetPasswordContext _forgetPasswordContext;
        public readonly EmployeeContext _employeeContext;

        public ForgetPasswordDA(ForgetPasswordContext forgetPasswordContext)
        {
            _forgetPasswordContext = forgetPasswordContext;
        }

        public ForgetPasswordDA(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public bool ForgetPasswordAuthentication(string userName)
        {
            try
            {
                string User = _employeeContext.Login.SingleOrDefault(s => s.UserName == userName).ToString();
                if (User != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void SaveForgetPasswordPage(ForgetPasswordDTO forgetPasswordDTO)
        {
            _employeeContext.Login.Where(s => s.UserName == forgetPasswordDTO.UserName).ToList();
            _employeeContext.SaveChanges();

        }
    }
}
