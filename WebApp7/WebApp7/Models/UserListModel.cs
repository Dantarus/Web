using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp7.Models
{
    public class UserListModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}