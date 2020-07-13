using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [HttpPost]
        public ActionResult FormLoginInput(string InputLogin, string InputPassword/*,string CheckBox*/)
        {
            string text = BaseUserData.DataLoginExist(InputLogin, InputPassword);
            ViewBag.Text = text;
                return View();
        }
        [HttpPost]
        public ActionResult FormRegisterInput(string InputLogin, string InputPassword, string InputConfirmPassword, string InputEmail/*,string CheckBox*/)
        {
            string text = BaseUserData.DataRegisterExist(InputLogin, InputPassword, InputConfirmPassword, InputEmail);
            ViewBag.Text = text;
            return View();
        }
    }
}