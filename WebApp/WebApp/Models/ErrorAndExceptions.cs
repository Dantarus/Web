using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ErrorAndExceptions
    {
        private static string text;
        //metoda zawiera komunikaty błędów występujących w trakcie rejestracji
        public static void RegisterError(int errorId) 
        {
            switch (errorId)
            {
                case 1:
                    text = "Wartość pola nie może pozostać pusta.";
                    break;
                case 2:
                    text = "Hasło i jego potwierdzenie nie są takie same.";
                    break;
                case 3:
                    text = "Login i hasło nie mogą być takie same.";
                    break;
                case 4:
                    text = "Na podany login lub email istnieje już konto.";
                    break;
                case 5:
                    text = "Rejestracja przebiegła pomyślnie.";
                    break;
                case 6:
                    text = "Dla podanych danych istnieje już konto.";
                    break;
                default:
                    text = "Rejestracja nie przebiegła pomyślnie.";
                    break;
            }
        }
        //metoda wypisująca komunikat błędu ze zmiennej string
        public static string GetRegisterStatus()
        {
            return text;
        }
    }
}