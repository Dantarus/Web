using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp7.Models;
using WebApp7.Manager;


namespace WebApp7.Controllers
{
    [Authorize(Roles ="admin")]
    public class DeleteUserController : Controller
    {
        [HttpGet]
        public ActionResult DeleteUser(int id=0)
        {
            InputDataUser userData = new InputDataUser();
            return View(userData);
        }
        [HttpPost]
        public ActionResult DeleteUser(WebApp7.Models.InputDataUser userData)
        {
            
            DeleteUserMenager.DeleteUserMethod(userData.Login);
            Session["DeleteUser"] = DeleteUserMenager.RegisterMessageText();
            return View(userData);
        }
    }
}