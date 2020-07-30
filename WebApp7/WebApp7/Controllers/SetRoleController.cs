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
    public class SetRoleController : Controller
    {
        [HttpGet]
        public ActionResult SetRole(int id=0)
        {
            Session["RoleMessage"] = null;
            UserRole userRole = new UserRole();
            return View("SetRole", userRole);
        }
        [HttpPost]
        public ActionResult SetRole(UserRole userRole)
        {
            SetRoleManager.SetRoleMethod(userRole);
            Session["RoleMessage"] = SetRoleManager.RegisterMessageText();
            return View("SetRole",new UserRole());
        }
    }
}