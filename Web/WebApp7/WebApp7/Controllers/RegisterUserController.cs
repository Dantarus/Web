using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApp7.Manager;
using WebApp7.Models;


namespace WebApp7.Controllers
{
    public class RegisterUserController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            Session["RegisterMessage"] = null;
            Session["EmailMessage"] = null;
            InputUserData userData = new InputUserData();
            return View(userData);
        }
        [HttpPost]
        public ActionResult Register(InputUserData userData)
        {
            RegisterMenager registerUser = new RegisterMenager();
            userData = registerUser.RegisterMethod(userData);
            Session["RegisterMessage"] = registerUser.RegisterMessageText();
            if (registerUser.ExecuteStatus())
            {
                EmailHandler sendEmail = new EmailHandler(userData, "Potwierdzenie Rejestracji", "Rejestacja przebiegła pomyślnie.\nWitaj ");
                sendEmail.CreateAndSendMessage();
                Session["EmailMessage"] = sendEmail.RegisterMessageText();

                    return RedirectToAction("Index", "Home");
                
                
            }
            ModelState.Clear();
            return View("Register", userData);

        }
    }
}