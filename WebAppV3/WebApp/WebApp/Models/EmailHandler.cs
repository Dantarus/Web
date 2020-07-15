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
    
        public static string test = "prawidłowo";
        public static void CreateAndSendMessage(string login, string email, string wiadomosc)
        {

            MailMessage message = new MailMessage()
            {
                From = new MailAddress(baseEmail),
                Subject = wiadomosc,
                Body = "Witamy w usłudze " + login + ".",
            };
           
            message.To.Add(new MailAddress(email));
            
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
                test = "Wysłano wiadomość o rejestracji";
            }
            catch(Exception exp)
            {
                test = "niewysłane" + exp;
                exp.Message.ToString();
                LogCreate.Logger(exp);
            }
        }
    }
}