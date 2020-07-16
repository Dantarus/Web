using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp6.Models;

namespace WebApp6.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: LoginUser
        [HttpGet]
        public ActionResult Login(int id=0)
        {
            Models.Table loginData = new Models.Table();
            return View(loginData);
        }
        [HttpPost]
        public ActionResult Login(Models.Table loginData)
        {
            using(UserDataEntities dbModel = new UserDataEntities())
            {
                if (dbModel.Table.Any(x => x.email == loginData.email) && dbModel.Table.Any(y => y.password == loginData.password))
                {
                     
                    ViewBag.SuccessMessage = "Logowanie przebiegło pomyślnie";
                    EmailHandler emailHandler = new EmailHandler(" ", loginData.email, "Logowanie na konto");
                    emailHandler.CreateAndSendMessage();
                    ViewBag.RegisterMessage = emailHandler.SendingStatus() + loginData.email + ".";

                }
                else
                {
                    ViewBag.SuccessMessage = "Błędne dane logowania";

                }

                return View("Login", new Models.Table());
            }
        }
    }
}