using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ErrorAndExceptions
    {
        private static string text= "Akcja przebiegła pomyślnie.";
        //metoda zawiera komunikaty błędów występujących w trakcie rejestracji
        public static Dictionary<int, string> errorDictionary = new Dictionary<int, string>()
        {
            {1, "Wartość pola nie może pozostać pusta."},
            {2, "Hasło i jego potwierdzenie nie są takie same."},
            {3, "Login i hasło nie mogą być takie same."},
            {4, "Dla podanych danych istnieje już konto."},
            {5, "Akcja przebiegła pomyślnie."},
            {6, "Rejestracja nie przebiegła pomyślnie."},
            {7, "Błędny email lub hasło" }
        };
            //{1, "Wartość pola nie może pozostać pusta."},
        public static void RegisterError(int errorId) 
        {
            text = errorDictionary[errorId];
        }
        //metoda wypisująca komunikat błędu ze zmiennej string
        public static string GetRegisterStatus()
        {
            return text;
        }
    }
}