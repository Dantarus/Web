using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class Form2Controller : Controller
    {
        // GET: Form2
        private static Logger logger = LogManager.GetLogger("myAppLoggerRules");
        public ActionResult FormLogin(Models.UserDataForm userData)
        {
            Base2UserData.DataLoginExist(userData);
            ViewBag.Text = ErrorAndExceptions.GetRegisterStatus();
            EmailHandler.CreateAndSendMessage(" ",userData.Email, "Logowanie");
            return View();
        }
        public ActionResult FormRegister(Models.UserDataForm userData)
        {
            logger.Info("Początek Rejestracji.");
            Base2UserData.DataRegisterExist(userData);
            EmailHandler.CreateAndSendMessage(userData.Login, userData.Email, "Logowanie");
            ViewBag.Test = EmailHandler.test;
            ViewBag.Text = ErrorAndExceptions.GetRegisterStatus();
            logger.Info(ErrorAndExceptions.GetRegisterStatus());
            logger.Info("Koniec Rejestracji.");
            return View();
        }
    }
}