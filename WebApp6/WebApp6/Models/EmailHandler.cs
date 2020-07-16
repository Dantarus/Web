using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Net;

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

            MailMessage message = new MailMessage()
            {
                From = new MailAddress(baseEmail),
                Subject = Message,
                Body = "Witamy w usłudze " + Login + ".",
            };

            message.To.Add(new MailAddress(Email));

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(baseEmail, basePassword),
                EnableSsl = true,
            };

            try
            {
                smtpClient.Send(message);
                test = "Wysłano potwierdzenie na email " + Email;
            }
            catch (Exception exp)
            {
                test = "Niewysłano potwierdzenie na email " + Email;
                exp.Message.ToString();
                //LogCreate.Logger(exp);
            }
        }

        public string SendingStatus()
        {
            return test;
        }
    }
}