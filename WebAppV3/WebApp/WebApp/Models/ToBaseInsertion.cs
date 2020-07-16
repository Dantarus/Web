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
using System.Windows;

namespace WebApp.Models
{
    public class ToBaseInsertion
    {
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Repozytorium\\WebAppV3\\WebApp\\WebApp\\App_Data\\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

        private static Logger logger = LogManager.GetLogger("myAppLoggerRules");
        public static void InsertData(string login, string password, string email)
        { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;

                command.Connection = connection;
                command.CommandText = "INSERT INTO dbo.[UserDataTable] (login,email,password) VALUES (@login, @email, @password) ";

                command.Parameters.Add("@login",login);
                command.Parameters.Add("@email",email);
                command.Parameters.Add("@password",Encryption.EncryptedString(password));

                connection.Open();
                try
                {
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Client Successfully added");
                    ErrorAndExceptions.RegisterStatus(0);
                }
                catch(Exception exp)
                {
                    logger.Info(exp);
                    ErrorAndExceptions.RegisterStatus(5);
                }
                command.Dispose();
                connection.Close();
            }
        }
    }
}