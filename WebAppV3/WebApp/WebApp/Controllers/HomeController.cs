using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {

            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        public ActionResult LogIn2()
        {

            return View();
        }
        public ActionResult Register2()
        {

            return View();
        }
        public PartialViewResult ErrorMessage()
        {
            return PartialView("_ErrorMessage");
        }   
    }
}