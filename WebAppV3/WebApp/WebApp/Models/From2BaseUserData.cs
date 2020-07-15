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
    public class Base2UserData
    {
        //connectionString dostępny we właściwościach bazy danych
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Repozytorium\\WebApp\\WebApp\\App_Data\\Database1.mdf;Integrated Security=True ";

        private static void ToBaseUserLogin(Models.UserDataForm userData)
        {
            //definiowanie zpaytania do bazy do inserowania wiersza tabeli
            string query = "INSERT INTO dbo.[UData](login, email, password) VALUES(@Login, @Email, @Password)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //zdediniowanie obiektu adapter do inseringu, kasowania i uaktualniania danych.
                SqlDataAdapter adapter = new SqlDataAdapter();
                //obiekt odpowiedzialny za połącznie
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", userData.Login.ToString());
                command.Parameters.AddWithValue("@Email", userData.Email.ToString());
                command.Parameters.AddWithValue("@Password", Encryption.EncryptionMethod(userData.Password).ToString());
                connection.Open();
                try
                {
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    ErrorAndExceptions.RegisterError(5);
                    /*EmailHandler.CreateAndSendMessage(userData.Login.ToString(), userData.Email.ToString());*/
                }
                catch (Exception)
                {
                    ErrorAndExceptions.RegisterError(6);
                }
                connection.Close();
                command.Dispose();
            }
        }
        private static void CheckLoginData(Models.UserDataForm userData)
        {
            int id;
            if (string.IsNullOrWhiteSpace(userData.Email) || string.IsNullOrWhiteSpace(userData.Password))
            {
                ErrorAndExceptions.RegisterError(1); // pole nie zostało wypełnione
            }
            else
            {
                string querty = "SELECT Id FROM dbo.[UData] WHERE email = @email AND password = @password";
               
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(querty, connection);
                    command.Parameters.AddWithValue("@email", userData.Email);
                    command.Parameters.AddWithValue("@password", Encryption.EncryptionMethod(userData.Password));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    try
                    {
                        id = (int)reader[0];
                        ErrorAndExceptions.RegisterError(5);
                    }
                    catch
                    {
                        ErrorAndExceptions.RegisterError(7);
                    }
                    connection.Close();
                    command.Dispose();
                }
            }
            
        }
        public static void DataLoginExist(Models.UserDataForm userData)
        {
            CheckLoginData(userData);
        }
        public static void CheckRegisterData(Models.UserDataForm userData)
        {
            int id;
            if (string.IsNullOrWhiteSpace(userData.Login) || string.IsNullOrWhiteSpace(userData.Password) || string.IsNullOrWhiteSpace(userData.ConfirmPassword) || string.IsNullOrWhiteSpace(userData.Email))
            {
                ErrorAndExceptions.RegisterError(1); // pole nie zostało wypełnione
            }
            else if (userData.Password != userData.ConfirmPassword)
            {
                ErrorAndExceptions.RegisterError(2);
            }
            else if (userData.Password == userData.Login)
            {
                ErrorAndExceptions.RegisterError(3);
            }
            else
            {
                string querty = "SELECT Id FROM dbo.[UData] WHERE login = @login OR email = @email";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(querty, connection);
                    command.Parameters.AddWithValue("@login", userData.Login.ToString());
                    command.Parameters.AddWithValue("@email", userData.Email.ToString());
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
                       ToBaseUserLogin(userData);
                    }
                    connection.Close();
                    command.Dispose();

                }

                
            }
            //return id;
        }
        public static void DataRegisterExist(Models.UserDataForm userData)
        {
            CheckRegisterData(userData);

        }
    }
}