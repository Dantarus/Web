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
    public class LoginUserController : Controller
    {
        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            Models.InputUserData loginData = new Models.InputUserData();
            return View(loginData);
        }
        [HttpPost]
        public ActionResult Login(Models.InputUserData loginData)
        {
            using (UserDataEntities dbModel = new UserDataEntities())
            {
                string pwd = loginData.Password;
                if (dbModel.Table.Any(x => x.Email == loginData.Email) && dbModel.Table.Any(y => y.Password == pwd))
                {
                    LogCreate.Logger(ViewBag.SuccessMessage);
                    try
                    {
                        EmailHandler emailHandler = new EmailHandler(" ", loginData.Email, "Logowanie na konto");
                        emailHandler.CreateAndSendMessage();
                        ViewBag.RegisterMessage = emailHandler.SendingStatus() + ".";
                        LogCreate.Logger(ViewBag.RegisterMessage);

                        Session["Komunikat"]= "Logowanie przebiegło pomyślnie";
                        FormsAuthentication.SetAuthCookie(loginData.Email, false);
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception exp)
                    {
                        LogCreate.Logger("Wysyłanie wiadomości nie przebiegło pomyślnie " + exp);
                    }


                }
                else
                {
                    ViewBag.SuccessMessage = "Błędne dane logowania";
                    LogCreate.Logger(ViewBag.SuccessMessage);

                }

                return View("Login", new Models.InputUserData());
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


        