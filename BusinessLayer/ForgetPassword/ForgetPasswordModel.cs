using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataAccessLayer.ForgetPassword;
using DataTransferObject.ForgetPassword;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.ForgetPassword
{

    public class ForgetPasswordModel
    {
        private readonly IForgetPassword _forgetPassword;
        private readonly IConfiguration _config;
        public ForgetPasswordModel(IForgetPassword forgetPassword,bool isCall, IConfiguration config)
        {
            _forgetPassword = forgetPassword;
            _config = config;
        }
   
        public void SaveForgetPasswordDetails(ForgetPasswordDTO passwordDTO) {
            _forgetPassword.SaveForgetPasswordPage(passwordDTO);
        }

        public bool VerifyUser(string userName) {

            bool verify = _forgetPassword.ForgetPasswordAuthentication(userName);
            return verify;
        }

        public string CreateToken() {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                //SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey();
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                var JWToken = new JwtSecurityToken(
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha256Signature)
            );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            catch (Exception ex) {
                throw ex;
            }
            }
    }
}
