using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApp7.Manager
{
    public class EncryptionManager
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        //metoda wykorzystywana do szyfrowania danych
        private static string encryptedText;
        private static void EncryptionMethod(string password)
        {
            try
            {
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                   
                        UTF8Encoding utf8 = new UTF8Encoding();
                        byte[] data = md5.ComputeHash(utf8.GetBytes(password));//tworzy klucz hash 
                        encryptedText = Convert.ToBase64String(data);//zwrócenie typu string z konwersji z byte
                        logger.Info("Szyfrowanie hasło przebiegło pomyślnie");
                  
                }
            }
            catch (Exception exp)
            {
                logger.Error("Szyfrowanie hasło nie przebiegło pomyślnie: " + "\n" + exp);
            }
        }
        public static string EncryptedString(string password)
        {
            EncryptionMethod(password);
            return encryptedText;
        }
    }
}