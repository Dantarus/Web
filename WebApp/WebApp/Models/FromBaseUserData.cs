using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApp.Models
{
    public class BaseUserData
    {
        private static string userPassword;
        private static string userLogin;
        //connectionString dostępny we właściwościach bazy danych
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Repozytorium\\WebApp\\WebApp\\App_Data\\Database1.mdf;Integrated Security=True ";

        //wydobycie z bazy elementu o podanym identyfikatorze
        private static void FromBaseUserPassword(int id)
        {
            //pobieranie danych przy pomocy technologii AdoNet
            //definiowanie zapytania do bazy danych
            string query = "SELECT password FROM dbo.[UData] WHERE id = @id";

            //utworzenie połącznia
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //obiekt odpowiedzialny za połącznie
                SqlCommand command = new SqlCommand(query, connection);

                //dodanie wybranego parametru
                command.Parameters.AddWithValue("@id", id);

                //Otwarcie połączenia z bazą
                connection.Open();
                //obiekt do Odczyti z bazy danych
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();


                userPassword = reader[0].ToString();

                connection.Close();

            }
        }
        //zwrócenie wartości rekordu z funkcji FromBaseUserLogin(int id)
        private static string GetPassword(int id)
        {
            FromBaseUserPassword(id);
            return userPassword;
        }
        private static void FromBaseUserLogin(int id)
        {
            //pobieranie danych przy pomocy technologii AdoNet
            //connectionString dostępny we właściwościach bazy danych


            //definiowanie zapytania do bazy danych
            string query = "SELECT login FROM dbo.[UData] WHERE id = @id";

            //utworzenie połącznia
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //obiekt odpowiedzialny za połącznie
                SqlCommand command = new SqlCommand(query, connection);

                //dodanie wybranego parametru
                command.Parameters.AddWithValue("@id", id);

                //Otwarcie połączenia z bazą
                connection.Open();
                //obiekt do Odczyti z bazy danych
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();


                userLogin = reader[0].ToString();

                connection.Close();

            }
        }
        //zwrócenie wartości rekordu z funkcji FromBaseUserLogin(int id)
        private static string GetLogin(int id)
        {
            FromBaseUserLogin(id);
            return userLogin;
        }
        public static void ToBaseUserLogin(string Login, string Password, string Email)
        {
            //definiowanie zpaytania do bazy do inserowania wiersza tabeli
            string query = "INSERT INTO dbo.[UData](login, email, password) VALUES(@Login, @Email, @Password)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //zdediniowanie obiektu adapter do inseringu, kasowania i uaktualniania danych.
                SqlDataAdapter adapter = new SqlDataAdapter();
                //obiekt odpowiedzialny za połącznie
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", Login);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Encryption.EncryptionMethod(Password));
                connection.Open();
                try
                {
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    ErrorAndExceptions.RegisterError(5);
                }
                catch (Exception)
                {
                    ErrorAndExceptions.RegisterError(6);
                }
                connection.Close();

            }
        }
        

        public static int CheckData(string InputLogin, string InputPassword)
        {
            int id;
            if (string.IsNullOrWhiteSpace(InputLogin) || string.IsNullOrWhiteSpace(InputPassword))
            {
                id = -1; // pole nie zostało wypełnione
            }
            else
            {
                string querty = "SELECT Id FROM dbo.[UData] WHERE login = @login AND password = @password";
               
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(querty, connection);
                    command.Parameters.AddWithValue("@login", InputLogin);
                    command.Parameters.AddWithValue("@password", Encryption.EncryptionMethod(InputPassword));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    try
                    {
                        id = (int)reader[0];
                    }
                    catch
                    {
                        id = -2;
                    }
                }
            }
            return id;
            
        }
        public static string DataLoginExist(string InputLogin, string InputPassword)
        {
            string text; 
            int correctnessid = CheckData(InputLogin, InputPassword);
            if (correctnessid == -1)
            {
                text = "Wartość pola nie może pozostać pusta.";
            }
            else if (correctnessid == -2)
            {
                text = "Podane dane logowania nie są prawidłowe.";
            }
            else
            {
                text = "Logowanie przebiegło pomyślnie";
                
            }
            return text;
        }
        public static void CheckRegisterData(string InputLogin, string InputPassword, string InputConfirmPassword, string InputEmail)
        {
            int id;
            if (string.IsNullOrWhiteSpace(InputLogin) || string.IsNullOrWhiteSpace(InputPassword) || string.IsNullOrWhiteSpace(InputConfirmPassword) || string.IsNullOrWhiteSpace(InputEmail))
            {
                ErrorAndExceptions.RegisterError(1); // pole nie zostało wypełnione
            }
            else if (InputPassword != InputConfirmPassword)
            {
                ErrorAndExceptions.RegisterError(2);
            }
            else if (InputPassword == InputLogin)
            {
                ErrorAndExceptions.RegisterError(2);
            }
            else
            {
                string querty = "SELECT Id FROM dbo.[UData] WHERE login = @login OR email = @email";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(querty, connection);
                    command.Parameters.AddWithValue("@login", InputLogin);
                    command.Parameters.AddWithValue("@email", InputEmail);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    try
                    {
                        id = (int)reader[0];
                        ErrorAndExceptions.RegisterError(4);
                    }
                    catch
                    {
                       ToBaseUserLogin(InputLogin, InputPassword, InputEmail);
                    }
                    connection.Close();
                }

                
            }
            //return id;
        }
        public static void DataRegisterExist(string InputLogin, string InputPassword, string InputConfirmPassword, string InputEmail)
        {
            CheckRegisterData(InputLogin, InputPassword, InputConfirmPassword, InputEmail);

        }
    }
}