using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp7.Models;
using WebApp7.Manager;

namespace WebApp7.Controllers
{
    [Authorize(Roles = "admin")]
    public class UpdateController : Controller
    {
        
        [HttpGet]
        public ActionResult UpdateUser(int id = 0)
        {
            Session["UpdateMessage"] = null;
            UpdateUserModel updateData = new UpdateUserModel();
            return View("UpdateUser", updateData);
        }
        [HttpPost]
        public ActionResult UpdateUser(UpdateUserModel updateData)
        {
            UserManagereManager update = new UserManagereManager();
            update.UpdateUserMethod(updateData);
            Session["UpdateMessage"] = update.RegisterMessageText();
            return View("UpdateUser", updateData);
        }
    }
}