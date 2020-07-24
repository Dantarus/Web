using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Net;
using System.Configuration;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Web.Services.Description;
using WebApp7.Models;

namespace WebApp7.Manager
{

    public class EmailHandler
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private static string Login;
        private static string Email;
        private static string MessageText;
        private static string SubjectText;
        

        static Dictionary<int, string> EmailMessage = new Dictionary<int, string>()
       {
            {0, "Nie wykonano żadnej akcji" },
            {1,"Niewysłano potwierdzenie na email"},
            {2,"Wysłano potwierdzenie na email" }
       };

        static string text = EmailMessage[0];
        private static bool executeStatus = false;
        public string RegisterMessageText()
        {
            return text;
        }
        public bool ExecuteStatus()
        {
            return executeStatus;
        }
  
        public EmailHandler(string login, string email, string subject, string message)
        {
            Login = login;
            Email = email;
            MessageText = message;
            SubjectText = subject;
        }
        public EmailHandler(InputUserData userData, string subject, string message)
        {
            Login = userData.Login;
            Email = userData.Email;
            MessageText = message;
            SubjectText = subject;

        }
        public void CreateAndSendMessage()
        {
            var appSettings = ConfigurationManager.AppSettings;
            MailMessage message = new MailMessage()
            {
                From = new MailAddress(appSettings["baseEmail"].ToString()),
                Subject = SubjectText,
                Body = MessageText + Login +".",
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
                executeStatus = true;
                text = EmailMessage[2];
                logger.Info(text);
            }
            catch (Exception exp)
            {
                text = EmailMessage[1];
                executeStatus = false;
                exp.Message.ToString();
                logger.Error(text + "\n" + exp);
            }
        }
    }
}