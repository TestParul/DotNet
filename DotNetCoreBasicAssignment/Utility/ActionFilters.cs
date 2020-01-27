using System;
using System.Collections.Generic;
using System.Linq;
using DataTransferObject.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCoreBasicAssignment.CommonRoutines
{
    public class ActionFilters : ActionFilterAttribute, IActionFilter
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LoginDTO loginDTO = new LoginDTO();

            if (context.Controller.ToString() != "DotNetCoreBasicAssignment.Controllers.Login.LoginController")
            {
                string loggedInUserName = context.HttpContext.Session.GetString("UserName");
                if (loggedInUserName != null)
                {
                    Console.WriteLine("logged in user verified");
                }
                else
                {
                    Console.WriteLine(loginDTO.UserName);
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

            
        }
    }
}
