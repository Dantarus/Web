using AutoMapper;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Web;
using WebApp7.Models;

namespace WebApp7.Manager
{
    public class LoginMenager
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static Dictionary<int, string> LoginMessage = new Dictionary<int, string>()
       {
            {0, "Nie wykonano żadnej akcji" },
            {1,"Email jest nieprawidłowy" },
            {2,"Hasło jest nieprawidłowe"},
            {3,"Logowanie przebiegło pomyślnie" }
       };


        private string text = LoginMessage[0];
        private bool executeStatus = false;
        public string LoginMessageText()
        {
            return text;
        }
        public bool ExecuteStatus()
        {
            return executeStatus;
        }

        public InputDataUser LoginMethod(InputDataUser userData)
        {

            try
            {
                using (UserDataEntities dbModel = new UserDataEntities())
                {
                    int? e = dbModel.isEmailExist(userData.Email).FirstOrDefault();
                    int? p = dbModel.isPasswordExist(EncryptionManager.EncryptedString(userData.Password)).FirstOrDefault();
                    if (e == 0)
                    {
                        text = LoginMessage[1];
                        executeStatus = false;
                        logger.Info(text);
                        return new InputDataUser();
                    }

                    if (p == 0)
                    {
                        text = LoginMessage[2];
                        executeStatus = false;
                        logger.Info(text);
                        return new InputDataUser();
                    }

                    if (e != 0 && p != 0)
                    {
                        text =  LoginMessage[3];
                        executeStatus = true;
                        logger.Info(text);
                        return userData;
                    }
                    else
                    {
                        text = LoginMessage[0];
                        executeStatus = false;
                        logger.Info(text);
                        return new InputDataUser();
                    }

                }
            }
            catch(Exception exp)
            {
                logger.Error(exp);
                return new InputDataUser();
            }
           
       
        
        }
    }
}

