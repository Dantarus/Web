using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebApp7.Models
{
    public class UpdateUserModel
    {
        public string Login { get; set; }
        public int UpdateOption { get; set; }
        public string UpdateText { get; set; }
    }

    public enum UpdateOptionName
    {
        Login,
        Email,
        Password,
    }
}