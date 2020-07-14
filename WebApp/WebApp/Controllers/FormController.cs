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
        //metoda przechwytuje wpisane do formularza dane logowania
        [HttpPost]
        public ActionResult FormLoginInput(string InputLogin, string InputPassword/*,string CheckBox*/)
        {
            string text = BaseUserData.DataLoginExist(InputLogin, InputPassword);
            ViewBag.Text = text;
            return View();
        }

        //metoda przechwytuje wpisane do formularza dane rejstracji
        [HttpPost]
        public ActionResult FormRegisterInput(string InputLogin, string InputPassword, string InputConfirmPassword, string InputEmail/*,string CheckBox*/)
        {
           BaseUserData.DataRegisterExist(InputLogin, InputPassword, InputConfirmPassword, InputEmail);
            ViewBag.Text = ErrorAndExceptions.GetRegisterStatus();
            return View();
        }
    }
}