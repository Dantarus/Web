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
    public class UserPanelController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        [Authorize]
            public ActionResult UserPanel()
            {
                return View(UserPanelMenager.GetUsersList());
            }
 
    }
}