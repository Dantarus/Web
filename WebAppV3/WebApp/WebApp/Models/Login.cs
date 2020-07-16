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
    public class Login
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Repozytorium\\WebApp\\WebApp\\App_Data\\Database1.mdf;Integrated Security=True ";
        private static void CheckLoginData(Models.UserDataForm userData)
        {
            int id;
            if (string.IsNullOrWhiteSpace(userData.Email) || string.IsNullOrWhiteSpace(userData.Password))
            {
                ErrorAndExceptions.RegisterStatus(1); // pole nie zostało wypełnione
            }
            else
            {
                string querty = "SELECT Id FROM dbo.[UData] WHERE email = @email AND password = @password";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(querty, connection);
                    command.Parameters.AddWithValue("@email", userData.Email);
                    command.Parameters.AddWithValue("@password", Encryption.EncryptedString(userData.Password));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    try
                    {
                        id = (int)reader[0];
                        ErrorAndExceptions.RegisterStatus(5);
                    }
                    catch
                    {
                        ErrorAndExceptions.RegisterStatus(7);
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
    }
}