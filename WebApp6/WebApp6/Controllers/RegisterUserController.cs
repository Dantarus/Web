using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApp.Models;
using WebApp6.Models;

namespace WebApp6.Controllers
{
    public class RegisterUserController : Controller
    {
        // GET: RegisterUser
        [HttpGet]
        public ActionResult Register(int id=0)
        {
            Models.Table userData = new Models.Table();
            return View(userData);
        }
        [HttpPost]
        public ActionResult Register(Models.Table userData)
        {
            using(UserDataEntities dbModel = new UserDataEntities())
            {
                if (dbModel.Table.Any(x => x.login == userData.login))
                {
                    ViewBag.DuplicateMessage = "Login jest już w użyciu";
                    return View("Register", userData);
                }
                if (dbModel.Table.Any(y => y.email == userData.email))
                {
                    ViewBag.DuplicateMessage = "Email jest już w użyciu";
                    return View("Register", userData);
                }
                string enc = Encryption.EncryptedString(userData.password);
               
                dbModel.Table.Add(userData);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Rejestacja Udana";

            EmailHandler emailHandler = new EmailHandler(userData.login,userData.email,"Rejestacja Udana");
            emailHandler.CreateAndSendMessage();
            ViewBag.RegisterMessage = emailHandler.SendingStatus() + userData.email +".";
            
            return View("Register", new Models.Table());
        }
    }
}