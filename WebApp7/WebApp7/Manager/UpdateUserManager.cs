using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp7.Models;

namespace WebApp7.Manager
{
    public class UserManagereManager
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static Dictionary<int, string> RegisterMessage = new Dictionary<int, string>()
       {
            {0,"Nie wykonano żadnej akcji" },
            {1,"Aktualizacja danych przebiegła pomyślnie" },
            {2,"Podany użytkownik nie istnieje" },
            {3,"Pola mają być uzupełnione" },
            
            
       };


        private string text = RegisterMessage[0];
        private bool executeStatus = false;
        public string RegisterMessageText()
        {
            return text;
        }
        public bool ExecuteStatus()
        {
            return executeStatus;
        }
        public void UpdateUserMethod(UpdateUserModel updateData)
        {
            try
            {
                using (UserDataEntities dbmodel = new UserDataEntities())
                {
                    int idMessage = (int)dbmodel.UpdateData(updateData.UpdateText, updateData.UpdateOption, updateData.Login).FirstOrDefault();
                    text = RegisterMessage[idMessage];
                    logger.Info(text);
                }
            }
            catch (Exception exp)
            {
                logger.Error(exp);
            }

        }
    }
}