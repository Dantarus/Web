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
        // GET: RegisterUser
        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            InputUserData userData = new InputUserData();
            return View(userData);
        }
        [HttpPost]
        public ActionResult Register(InputUserData userData)
        {
            using (UserDataEntities dbModel = new UserDataEntities())
            {
                string z = userData.Login;
                if (dbModel.Table.Any(x => x.Login == z))
                {
                    ViewBag.DuplicateMessage = "Login jest już w użyciu";
                    return View("Register", userData);
                }
                string m = userData.Email;
                if (dbModel.Table.Any(y => y.Email == m))
                {
                    ViewBag.DuplicateMessage = "Email jest już w użyciu";
                    return View("Register", userData);
                }
                Session["NYGGA"] = "0";

                //userData.Password = EncryptionManager.EncryptedString(userData.Password);

                WebApp7.Models.Table NewEntryBase = AutoMapperManager.Mapper(userData);

                dbModel.Table.Add(NewEntryBase);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            //ViewBag.SuccessMessage = "Rejestacja Udana";

            //{
            //    EmailHandler emailHandler = new EmailHandler(userData.Login, userData.Email, "Rejestacja Udana");
            //    emailHandler.CreateAndSendMessage();
            //    ViewBag.RegisterMessage = emailHandler.SendingStatus() + ".";
            //}
            

            return View("Register", new Models.InputUserData());
        }
    }
}