using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp7.Models;
using NLog;
using AutoMapper;
using WebApp7.Manager;

namespace WebApp7.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class UserPanelController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        [Authorize]
            public ActionResult UserPanel()
            {
                var userList = UserPanelMenager.GetUsersList();
                return View(userList);
            }
 
    }
}