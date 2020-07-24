using MySqlX.XDevAPI;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApp7.Models;

namespace WebApp7.Manager
{
    public class RegisterMenager
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static Dictionary<int, string> RegisterMessage = new Dictionary<int, string>()
       {
            {0,"Nie wykonano żadnej akcji" },
            {1,"Login jest już w użyciu" },
            {2,"Email jest już w użyciu"},
            {3,"Rejestacja przebiegła pomyślnie" }
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

        public InputUserData RegisterMethod(InputUserData userData)
        {
            try
            {
            using (UserDataEntities dbModel = new UserDataEntities())
            {
                string z = userData.Login;
                if (dbModel.Table.Any(x => x.Login == z))
                {
                    text = RegisterMessage[1];
                    executeStatus = false;
                    logger.Info(text);
                    return new InputUserData();
                }
                string m = userData.Email;
                if (dbModel.Table.Any(y => y.Email == m))
                {
                    text = RegisterMessage[2];
                    logger.Info(text);
                    executeStatus = false;
                    return new InputUserData();
                }


                userData.Password = EncryptionManager.EncryptedString(userData.Password);

                WebApp7.Models.Table NewEntryBase = AutoMapperManager.Mapper(userData);

                dbModel.InsertUserData(userData.Login, userData.Email, userData.Password);

                //dbModel.Table.Add(NewEntryBase);
                //try
                //{
                //    dbModel.SaveChanges();
                    logger.Info("Dane użytkownika zostały zapisane w bazie.");
                //}
                //catch (Exception exp)
                //{
                    //logger.Error(exp);
                //}

                text = RegisterMessage[3];
                executeStatus = true;

            }
            return userData;
            }
            catch (Exception exp)
            {
                logger.Error("Nie utworzono obiektu na podstawie bazy.\n" + exp);
                return new InputUserData();
            }
        }
    }
}