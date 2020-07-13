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
            //pobieranie danych przy pomocy technologii AdoNet
            //connectionString dostępny we właściwościach bazy danych
            //string Login = BaseUserData.GetLogin(2);
            //string Password = BaseUserData.GetPassword(2);
            //string ExistInBase = BaseUserData.DataExist(Login, Password);
            //ViewBag.Login = Login;
            //ViewBag.Password = Password;
            //ViewBag.ExistInBase = ExistInBase;
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
            
    }
}