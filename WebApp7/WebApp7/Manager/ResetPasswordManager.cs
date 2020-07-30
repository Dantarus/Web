using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApp7.Models;
namespace WebApp7.Manager
{
    public class ResetPasswordManager
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static Dictionary<int, string> RegisterMessage = new Dictionary<int, string>()
       {
            {0,"Nie wykonano żadnej akcji" },
            {1,"Podany użytkownik nie istnieje" },
            {2,"Email jest już w użyciu"},
            {3,"Resetowanie hasła przebiegło pomyślnie" },
            {4,"Hasło powinno zawierać jedną literę, jedną liczbę i mieć conajmniej 6 znaków." },

       };


        private string text = RegisterMessage[0];
        private bool executeStatus = false;
        private string randomPassword = "";
        public string RegisterMessageText()
        {
            return text;
        }
        public string GeneratedPassword()
        {
            return randomPassword;
        }
        public bool ExecuteStatus()
        {
            return executeStatus;
        }
        private string RandomPassword()
        {
            string pattern = "abcdefghijklmnoprstwuxyz1234567890";
            Random rand = new Random();
            for(int i = 0; i < 10; i++)
            {
                randomPassword += pattern[rand.Next() % pattern.Length];
            }
            return randomPassword;
        }
        public InputDataUser ResetMethod(InputDataUser resetData)
        {
            try
            {
                using (UserDataEntities dbModel = new UserDataEntities())
                {
                    resetData.Password = EncryptionManager.EncryptedString(RandomPassword());
                    resetData.Login = dbModel.GetLogin(resetData.Email).FirstOrDefault();
                    Users NewEntryBase = AutoMapperManager.Mapper(resetData);

                    try
                    {
                        dbModel.UpdateData(NewEntryBase.Password, 3, NewEntryBase.Login);
                        logger.Info("Hasło zostało zresetowane w bazie.");
                    }
                    catch (Exception exp)
                    {
                        logger.Error(exp);
                    }

                    text = RegisterMessage[3];
                    executeStatus = true;

                }
                return resetData;
            }
            catch (Exception exp)
            {
                logger.Error("Nie utworzono obiektu na podstawie bazy.\n" + exp);
                return new InputDataUser();
            }
        }
    }
}