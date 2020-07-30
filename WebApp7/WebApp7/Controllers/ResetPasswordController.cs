using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp7.Manager;
using WebApp7.Models;

namespace WebApp7.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class ResetPasswordController : Controller
    {
        [HttpGet]
        public ActionResult ResetPassword(int id = 0)
        {
            Session["ResetMessage"] = null;
            Session["EmailMessage"] = null;
            InputDataUser resetData = new InputDataUser();
            return View(resetData);
        }
        [HttpPost]
        public ActionResult ResetPassword(InputDataUser resetData)
        {
            resetData.Email = User.Identity.Name;
            ResetPasswordManager resetPassword = new ResetPasswordManager();
            resetData = resetPassword.ResetMethod(resetData);
            Session["ResetMessage"] = resetPassword.RegisterMessageText();
            var dbmodel = new UserDataEntities();
            if (resetPassword.ExecuteStatus())
            {
                EmailHandler sendEmail = new EmailHandler(resetData, "Zresowanie Hasła", "Hasło zostało Zresetowane");
                sendEmail.CreateAndSendMessage();
                Session["EmailMessage"] = sendEmail.RegisterMessageText();
                return RedirectToAction("Index", "Home");
            }
            ModelState.Clear();
            return View("ResetPassword", resetData);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RandomPassword(int id = 0)
        {
            Session["ResetMessage"] = null;
            Session["EmailMessage"] = null;
            InputDataUser resetData = new InputDataUser();
            return View(resetData);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult RandomPassword(InputDataUser resetData)
        {
            ResetPasswordManager resetPassword = new ResetPasswordManager();
            
            resetData = resetPassword.ResetMethod(resetData);
            Session["ResetMessage"] = resetPassword.RegisterMessageText();
            var dbmodel = new UserDataEntities();
            if (resetPassword.ExecuteStatus())
            {
                EmailHandler sendEmail = new EmailHandler(resetData, "Zresowanie Hasła", "Twoje tymczasowe hasło: " + resetPassword.GeneratedPassword() + " użytkowniku ");
                sendEmail.CreateAndSendMessage();
                Session["EmailMessage"] = sendEmail.RegisterMessageText();
                return RedirectToAction("Index", "Home");
            }
            ModelState.Clear();
            return View("ResetPassword", resetData);

        }
    }
}