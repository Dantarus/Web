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
            {3,"Rejestacja przebiegła pomyślnie" },
            {4,"Hasło powinno zawierać jedną literę, jedną liczbę i mieć conajmniej 6 znaków." },
            {5,"Email zawiera niedozwolone znaki." }
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

        public InputDataUser RegisterMethod(InputDataUser userData)
        {
            try
            {
            using (UserDataEntities dbModel = new UserDataEntities())
            {
                string z = userData.Login;
                if(!RegexTextValidationManager.RegexValidationPassword(userData.Password))
                {
                        text = RegisterMessage[4];
                        executeStatus = false;
                        logger.Info(text);
                        return new InputDataUser();
                }
                if (!RegexTextValidationManager.RegexValidationEmail(userData.Email))
                {
                    text = RegisterMessage[5];
                    executeStatus = false;
                    logger.Info(text);
                    return new InputDataUser();
                }
                if (dbModel.isLoginExist(userData.Login).FirstOrDefault() >= 1)
                {
                    text = RegisterMessage[1];
                    executeStatus = false;
                    logger.Info(text);
                    return new InputDataUser();
                }
                string m = userData.Email;
                if (dbModel.isEmailExist(userData.Email).FirstOrDefault() >= 1)
                {
                    text = RegisterMessage[2];
                    logger.Info(text);
                    executeStatus = false;
                    return new InputDataUser();
                }

                userData.Password = EncryptionManager.EncryptedString(userData.Password);

                Users NewEntryBase = AutoMapperManager.Mapper(userData);

                try
                {
                    dbModel.InsertData(NewEntryBase.Login, NewEntryBase.Password, NewEntryBase.Email);
                    logger.Info("Dane użytkownika zostały zapisane w bazie.");
                }
                catch (Exception exp)
                {
                    logger.Error(exp);
                }

                text = RegisterMessage[3];
                executeStatus = true;

            }
            return userData;
            }
            catch (Exception exp)
            {
                logger.Error("Nie utworzono obiektu na podstawie bazy.\n" + exp);
                return new InputDataUser();
            }
        }
    }
}