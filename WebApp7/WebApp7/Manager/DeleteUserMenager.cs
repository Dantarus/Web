using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApp7.Models;

namespace WebApp7.Manager
{
    public class DeleteUserMenager
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static Dictionary<int, string> RegisterMessage = new Dictionary<int, string>()
       {
            {0,"Nie wykonano żadnej akcji" },
            {1,"Podany użytkownik nie istnieje" },
            {2,"Użytkownik został usunięty"},
            {3, "Użytkownik nie został usunięty" }
       };
        private static bool executeStatus = false;
        public static string RegisterMessageText()
        {
            return text;
        }
        public static bool ExecuteStatus()
        {
            return executeStatus;
        }
        public static void DeleteUserMethod(string Login)
        {
            try
            {
                using (UserDataEntities dbmodel = new UserDataEntities())
                {
                    if(dbmodel.isLoginExist(Login).FirstOrDefault() == 1)
                    {
                        dbmodel.DeleteUser(Login);
                        ErrorSuccessInfoMessage.SuccessMessage(2);
                    }
                    else
                    {
                        ErrorSuccessInfoMessage.ErrorMessage(15);
                    }
                    
                }
            }
            catch(Exception exp)
            {
                ErrorSuccessInfoMessage.ErrorMessage(2);
                ErrorSuccessInfoMessage.ErrorMessage(20, exp);
            }
            
        }
        
    }
}