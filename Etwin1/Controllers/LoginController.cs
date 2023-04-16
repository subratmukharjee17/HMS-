using Etwin.BAL.Services;
using EtwLogin.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Web;


namespace Etwin1.Controllers
{
    public class LoginController : Controller
    {
        public readonly AuthenticationService _service;
        const string userName = "_UserName";

        public LoginController(AuthenticationService service) 
        {
        _service= service;
        }    
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
       
        public ActionResult Loginview(string username, string Password)
        {
            var issuccess = _service.AuthenticateUser(username, Password);

            if(username==null)
            {
                return View();
            }
            if (issuccess.Result != null)
            {
                string name = HttpContext.Session.GetString(username);
              
                TempData["Key"] = username;
                return RedirectToAction("Index", "Dashboard", TempData["Key"]);
               
            }
            else
            {
                ViewBag.username = string.Format("Invalid Credential ", username);
                return Json(new { Message = ViewBag.username, System.Web.Mvc.JsonRequestBehavior.AllowGet });
            }
           
        }

        public ActionResult Welcome()
        {

            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();
        }
        public ActionResult PasswordRecovery()
        {
            return View();
        }

        public async Task<ActionResult> PasswordRecoveryEmail(string emailId)
        {
           
            if (await _service.SendEmail(emailId))
                TempData["RecoveryMessage"] = "An email has been sent to you with instructions to reset your password.";
            else
                TempData["RecoveryMessage"] = "There was an issue sending you the instructions to reset your password.";
            TempData.Keep("RecoveryMessage");
            return View("PasswordRecovery");
        }
    }
}
