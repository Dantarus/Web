using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp7.Manager;
using WebApp7.Models;

namespace WebApp7.Controllers
{
    [AllowAnonymous]
    public class LoginUserController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            Session["LoginMessage"] = null;
            Session["EmailMessage"] = null;
            InputDataUser loginData = new InputDataUser();
            return View(loginData);
        }
        [HttpPost]
        public ActionResult Login(InputDataUser userData)
        {
            LoginMenager loginUser = new LoginMenager();
            userData = loginUser.LoginMethod(userData);
            Session["LoginMessage"] = loginUser.LoginMessageText();
            
            if (loginUser.ExecuteStatus())
            {
                EmailHandler sendEmail = new EmailHandler(userData, "Powiadomienie o logowaniu", "Ktoś zalogował się na konto.\nCzy to ty ");
                sendEmail.CreateAndSendMessage();
                Session["EmailMessage"] = sendEmail.RegisterMessageText();
                FormsAuthentication.SetAuthCookie(userData.Email, false);
                return RedirectToAction("Index", "Home", userData);
               
            }
            else
            {
                return View("Login", userData);
            }
            
            
            
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            LogCreate.Logger("Wylogowano");
            return RedirectToAction("Login");

        }
    }
}


        