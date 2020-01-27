using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataTransferObject.ForgetPassword;
using DataAccessLayer.ForgetPassword;
using BusinessLayer.ForgetPassword;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBasicAssignment.Controllers
{
    [AllowAnonymous]
    public class ForgetPasswordController : Controller
    {
        private readonly IForgetPassword _forgetPassword;
        private readonly IConfiguration _config;
        public ForgetPasswordController(IForgetPassword forgetPassword, IConfiguration config)
        {
            _forgetPassword = forgetPassword;
            _config = config;
        }

        [HttpGet]
        [Route("ForgetPassword/ForgetPassword/{UserName}/{Token}")]
        public IActionResult ForgetPassword()
        {
            ForgetPasswordDTO forgetPasswordDTO = new ForgetPasswordDTO
            {
                UserName = (string)this.RouteData.Values["UserName"]
            };
            return View("ForgetPassword", forgetPasswordDTO);
        }

        
        //[Route("ForgetPassword/ForgetPassword")]
        public IActionResult SaveForgetPasswordDetails(ForgetPasswordDTO forgetPasswordDTO)
        {
            ForgetPasswordModel forgetPasswordObj = new ForgetPasswordModel(_forgetPassword, true, _config);
            forgetPasswordObj.SaveForgetPasswordDetails(forgetPasswordDTO);
            return View();
        }

        [HttpGet]
        public ActionResult VerifyUser()
        {
            return View();
        }

        [HttpPost]
        public JsonResult VerifyUser(ForgetPasswordDTO forgetPasswordDTO)
        {
            ForgetPasswordModel forgetPasswordObj = new ForgetPasswordModel(_forgetPassword, true, _config);
            string userName = forgetPasswordDTO.UserName;
            bool isExists =  forgetPasswordObj.VerifyUser(userName);
            if (isExists == true)
            {
                string Token = forgetPasswordObj.CreateToken();
                return Json(Token);
            }
            else
                return Json(false);
        }
    }
}
