using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApp.Models
{
    public class ErrorAndExceptions
    {
        private static string text= "Akcja przebiegła pomyślnie.";
        private static int idStatusLogin = 5;
        private static int idStatusRegister = 5;
        private static Logger logger = LogManager.GetLogger("myAppLoggerRules");
        //metoda zawiera komunikaty błędów występujących w trakcie rejestracji
        public static Dictionary<int, string> errorRegisterDictionary = new Dictionary<int, string>()
        {
            {0, "Rejestracja przebiegła pomyślnie."},
            {1, "Wartość pola nie może pozostać pusta."},
            {2, "Hasło i jego potwierdzenie nie są takie same."},
            {3, "Login i hasło nie mogą być takie same."},
            {4, "Dla podanych danych istnieje już konto."},
            {5, "Rejestracja nie przebiegła pomyślnie."},
        };
        public static Dictionary<int, string> errorLoginDictionary = new Dictionary<int, string>()
        {
            {0, "Rejestracja przebiegła pomyślnie."},
            {1, "Wartość pola nie może pozostać pusta."},
            {2, "Hasło i jego potwierdzenie nie są takie same."},
            {3, "Login i hasło nie mogą być takie same."},
            {4, "Dla podanych danych istnieje już konto."},
            {5, "Rejestracja nie przebiegła pomyślnie."},
        };
        //{1, "Wartość pola nie może pozostać pusta."},
        public static void RegisterStatus(int errorId) 
        {
            text = errorRegisterDictionary[errorId];
            idStatusRegister = errorId;
            logger.Info(text);
        }
        public static void LoginStatus(int errorId)
        {
            text = errorLoginDictionary[errorId];
            idStatusLogin = errorId;
            logger.Info(text);
        }
        
        public static int LoginIdStatus()
        {
            return idStatusLogin;
        }
        public static int RegisterIdStatus()
        {
            return idStatusRegister;
        }
        //metoda wypisująca komunikat błędu ze zmiennej string
        public static string GetRegisterStatus()
        {
            return text;
        }
    }
}