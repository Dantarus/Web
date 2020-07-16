using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApp.Models;

namespace WebApp.Models
{
    public class Register
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Repozytorium\\WebApp\\WebApp\\App_Data\\Database1.mdf;Integrated Security=True ";
        private static void CheckRegisterData(string login, string password, string confirm_password, string email)
        {
            int id;
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm_password) || string.IsNullOrWhiteSpace(email))
            {
                ErrorAndExceptions.RegisterStatus(1);/// pole nie zostało wypełnione
            }
            else if (password != confirm_password)
            {
                ErrorAndExceptions.RegisterStatus(2);//Hasło i jego potwierdzenie nie są takie same
            }
            else if (password == login)
            {
                ErrorAndExceptions.RegisterStatus(3);//Login i hasło nie mogą być takie same
            }
            else
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    command.CommandText = "SELECT Id FROM dbo.[UData] WHERE login = @login OR email = @email";

                    command.Parameters.Add("@login", SqlDbType.VarChar, 40).Value = login;
                    command.Parameters.Add("@email", SqlDbType.VarChar, 40).Value = email;

                    

                    connection.Open();
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        command.ExecuteNonQuery();
                        id = (int)reader[0];
                        ErrorAndExceptions.RegisterStatus(4);//Dla podanych danych istnieje już konto
                    }
                    catch (Exception)
                    {
                        ErrorAndExceptions.RegisterStatus(0);
                    }
                    command.Dispose();
                    connection.Close();
                }
            }
        }
        public static void DataRegister(string login, string password, string confirm_password, string email)
        {
            CheckRegisterData(login, password, confirm_password, email);
            if (ErrorAndExceptions.RegisterIdStatus() == 0)
            {
                ToBaseInsertion.InsertData(login, password, email);
            }
            
                EmailHandler.CreateAndSendMessage(login, email, "Rejestracja");
            
        }
    }
}