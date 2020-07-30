using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebApp7.Manager;
using WebApp7.Models;


namespace WebApp7.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [HttpGet]
        public ActionResult Register(int id = 0)
        {Session["RegisterMessage"] = null;
            Session["EmailMessage"] = null;
            InputDataUser userData = new InputDataUser();
            return View(userData);
            
        }
        [HttpPost]
        public ActionResult Register(InputDataUser userData)
        {
            RegisterMenager registerUser = new RegisterMenager();
            userData = registerUser.RegisterMethod(userData);
            Session["RegisterMessage"] = registerUser.RegisterMessageText();
            if (registerUser.ExecuteStatus())
            {
                EmailHandler sendEmail = new EmailHandler(userData, "Potwierdzenie Rejestracji", "Rejestacja przebiegła pomyślnie.\nWitaj ");
                sendEmail.CreateAndSendMessage();
                Session["EmailMessage"] = sendEmail.RegisterMessageText();
                FormsAuthentication.SetAuthCookie(userData.Email, false);
                return RedirectToAction("Index", "Home"); 
            }
            ModelState.Clear();
            return View("Register", userData);

        }
    }
}