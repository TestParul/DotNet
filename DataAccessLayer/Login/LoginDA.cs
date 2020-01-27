using DataTransferObject;
using DataTransferObject.Login;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataAccessLayer.Login
{
    public class LoginDA : ILogin
    {
        private readonly EmployeeContext _dbContext;
        public LoginDA(EmployeeContext dbContext)

        {
            _dbContext = dbContext;
        }

        public void SaveUserLoginDetails(LoginDTO loginDTO) {
            _dbContext.Add(loginDTO);
            _dbContext.SaveChanges();
        }

        public bool AuthenticateUser(LoginDTO loginDTO)
        {
            try
            {
                var checkUser = _dbContext.Login.Where(login => login.UserName == loginDTO.UserName
                        && login.Password == loginDTO.Password).FirstOrDefault();
                DbCommand cmd = _dbContext.Database.GetDbConnection().CreateCommand();
;
                var test = _dbContext.Database.ExecuteSqlCommand("exec LoginDetails 'parul'");

                if (checkUser != null)
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
    }
}
