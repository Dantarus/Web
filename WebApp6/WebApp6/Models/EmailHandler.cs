using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Net;
using System.Configuration;

namespace WebApp.Models
{
    public class EmailHandler
    {
        private static readonly string baseEmail = "testowybaza@gmail.com";
        private static readonly string basePassword = "#20testowyBaza";
        private static string Login;
        private static string Email;
        private static string Message;
       
        public EmailHandler()
        {

        }
        public EmailHandler(string login, string email, string message)
        {
            Login = login;
            Email = email;
            Message = message;
        }

        public static string test = "prawidłowo";
        public void CreateAndSendMessage()
        {
            var appSettings = ConfigurationManager.AppSettings;
            MailMessage message = new MailMessage()
            {
                From = new MailAddress(appSettings["baseEmail"].ToString()),
                Subject = Message,
                Body = "Witamy w usłudze " + Login + ".",
            };

            message.To.Add(new MailAddress(Email));

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = appSettings["Host"].ToString(),//"smtp.gmail.com",
                Port = Int32.Parse(appSettings["Port"].ToString()),
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(appSettings["baseEmail"].ToString(), appSettings["basePassword"].ToString()),
                EnableSsl = true,
            };
            try
            {
                smtpClient.Send(message);
                test = "Wysłano potwierdzenie na email " + Email;
                LogCreate.Logger(test);
            }
            catch (Exception exp)
            {
                test = "Niewysłano potwierdzenie na email " + Email;
                exp.Message.ToString();
                LogCreate.Logger(test);
            }
        }

        public string SendingStatus()
        {
            return test;
        }
    }
}