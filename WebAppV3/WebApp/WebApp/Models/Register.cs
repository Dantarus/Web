using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Register
    {
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