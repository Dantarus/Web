using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp7.Manager
{
    
    
    public class ErrorSuccessInfoMessage
    {
        static Dictionary<int, string> Error = new Dictionary<int, string>()
    {
        {0,"Nie wykonano żadnej akcji" },

        {1, "Nie Dodano użytkownika do bazy" },
        {2, "Nie usunięto użytkownika z bazy" },
        {3, "Logowanie nie przebiegło prawidłowo" },
        {4,"Rejestacja przebiegła prawidłowo" },
        {5, "Nie wysłano potwierdzenie na email" },
        {6, "Hasło nie zostało zresetowane" },
        {7, "Uprawnienia nie zostały przydzielone" },
        {8,"Aktualizacja danych nie przebiegła prawidłowo" },
        {9,"Aktualizacja loginu nie przebiegła prawidłowo" },
        {10,"Aktualizacja emailu nie przebiegła prawidłowo" },
        {11,"Aktualizacja hasła nie przebiegła prawidłowo" },
        {12,"Login jest nieprawidłowy" },
        {13,"Hasło jest nieprawidłowe"},
        {14,"Email jest nieprawidłowy" },
        {15,"Podany użytkownik nie istnieje" },
        {16,"Login jest już w użyciu" },
        {17,"Email jest już w użyciu"},
        {18,"Wymagane są uzupełnione wszystkie pola" },
        {19,"Błąd w bloku automappera" },
        {20,"Błąd w bloku usuwania" },



    };
        static Dictionary<int, string> Success = new Dictionary<int, string>()
    {
        {1, "Dodano użytkownika do bazy" },
        {2, "Usunięto użytkownika z bazy" },
        {3, "Logowanie przebiegło prawidłowo" },
        {4, "Rejestacja przebiegła prawidłowo" },
        {5, "Wysłano potwierdzenie na email" },
        {6, "Hasło zostało zresetowane" },
        {7, "Uprawnienia zostały przydzielone" },
        {8,"Aktualizacja danych przebiegła prawidłowo" },
        {9,"Aktualizacja loginu przebiegła prawidłowo" },
        {10,"Aktualizacja emailu przebiegła prawidłowo" },
        {11,"Aktualizacja hasła przebiegła prawidłowo" },
        {12,"Login jest prawidłowy" },
        {13,"Hasło jest prawidłowe"},
        {14,"Email jest prawidłowy" },
        {15,"Podany użytkownik istnieje" },
        {16,"Login nie jest w użyciu" },
        {17,"Email nie jest w użyciu"},
        {19,"Automapper zadziałał prawidłowo" },

    };
        static Dictionary<int, string> Info = new Dictionary<int, string>()
     {
        {1,"Login i hasło nie mogą być takie same" },

        {2,"Hasło powinno zawierać jedną literę, jedną liczbę i mieć conajmniej 6 znaków." },
        {2,"Hasło powinno zawierać" +
             "1. Wielkie i małe litery" +
             "2. Od 8 do 20 znaków" +
             "3. Co najmniej 1 litera" +
             "4. Co najmniej 1 cyfra lub specjalny" +
             "5. Tylko te znaki specjalne ~ ! @ # $% ^ & ? * +"},
        {4,"Email zawiera niedozwolone znaki." },
        {5,"Email powinno zawierać " +
             "1. Wielkie i małe litery " +
             "2. Cyfry od 0 do 9 " +
             "3. Znaki ! # $% & '* + - / = ? ^ _` {|} ~ " +
             "4. Znak „.” pod warunkiem, że nie jest to pierwszy ani ostatni znak" },
     };

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static string error = null, success = null, info = null;
        public static void ErrorMessage(int id)
        {
            logger.Error(Error[id]);
            error = Error[id];
        }
        public static void ErrorMessage(int id, Exception exp)
        {
            logger.Error(Error[id] +"\n" + exp);
            error = Error[id];
        }
        public static void SuccessMessage(int id)
        {
            logger.Info(Success[id]);
            success = Success[id];
        }
        public static void InfoMessage(int id)
        {
            info = error;
        }

        public static string ReturnErrorMessage(int id, Exception exp)
        {
            return info;
        }
        public static string ReturnSuccessMessage(int id)
        {
           return success;
        }
        public static string ReturnInfoMessage(int id)
        {
            logger.Info(Info[id]);
            return info;
        }

    }
}