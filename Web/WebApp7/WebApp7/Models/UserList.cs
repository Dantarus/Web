using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApp7.Models
{
    public class UserList
    {
        public string Login { get; set; }
        public string Email { get; set; }

        UserList(string login, string email)
        {
            Login = login;
            Email = email;
        }
    }
}