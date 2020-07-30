using NLog;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp7.Models;

namespace WebApp7.Manager
{
    public class SetRoleManager
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static Dictionary<int, string> RegisterMessage = new Dictionary<int, string>()
       {
            {0,"Nie wykonano żadnej akcji" },
            {1,"Podany login nie istnieje" },
            {2,"Uprawnienia zostały przydzielone" },
       };


        private static string text = RegisterMessage[0];
        private static bool executeStatus = false;
        public static string RegisterMessageText()
        {
            return text;
        }
        public static bool ExecuteStatus()
        {
            return executeStatus;
        }
        public static void SetRoleMethod(UserRole userRole)
        {
            try
            {
                using (UserDataEntities dbmodel = new UserDataEntities())
                {
                    var x = dbmodel.isLoginExist(userRole.User).FirstOrDefault();
                    if (dbmodel.isLoginExist(userRole.User).FirstOrDefault() == 1)
                    {
                        dbmodel.SetRole(userRole.User, userRole.Role);
                        text = RegisterMessage[2];
                        logger.Info(text);
                    }
                    else
                    {
                        text = RegisterMessage[1];
                        logger.Info(text);
                    }

                }
            }
            catch(Exception exp)
            {
                logger.Error(exp);
            }
            
        }
    }
}