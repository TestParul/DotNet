using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataTransferObject.Login;
using DataAccessLayer.Login;
using BusinessLayer.Login;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using DotNetCoreBasicAssignment.CommonRoutines;

namespace DotNetCoreBasicAssignment.Controllers.Login
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [BindProperty]
        public LoginDTO loginData { get; set; }
        private readonly ILogin ilogin;

        public LoginController(ILogin login)
        {
            ilogin = login;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDTO login)
        {
            LoginModel objLogin = new LoginModel(ilogin);
            bool checkUserExists = objLogin.validateUser(login);
            if (checkUserExists)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginData.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, loginData.UserName));
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                } );
                HttpContext.Session.SetString("UserName", loginData.UserName);
                return RedirectToAction("GetEmployees", "Employee");
            }
            else {
                ModelState.AddModelError("", "username or password is blank");
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignIn() {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginDTO loginDTO)
        {
            LoginModel objLogin = new LoginModel(ilogin);
            objLogin.saveUserLoginData(loginDTO);
            return View("Login");
        }

        public ActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            return Redirect("Login");
        }
    }
}
