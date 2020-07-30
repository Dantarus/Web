using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApp7.Manager
{
    public class RegexTextValidationManager
    {
        public static bool RegexValidationEmail(string text)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            string pattern2 = @"^((([!#$%&'*+\-/=?^_`{|}~\w])|([!#$%&'*+\-/=?^_`{|}~\w][!#$%&'*+\-/=?^_`{|}~\.\w]{0,}[!#$%&'*+\-/=?^_`{|}~\w]))[@]\w+([-.]\w+)*\.\w+([-.]\w+)*)$";

            Regex rgx = new Regex(pattern);
            MatchCollection matchtext = rgx.Matches(text);
            if (matchtext.Count > 0) return true;
            else return false;
        }
        public static bool RegexValidationPassword(string text)
        {
            string pattern = "^(?=.*[a-zA-Z])(?=.*[0-9!@#$%^&*\\?\\+])(?!.*[()_\\-\\`\\/\"\'|\\[\\]}{:;'/>.<,])(?!.*\\s)(?!.*\\s).{8,20}$";
            Regex rgx = new Regex(pattern);
            MatchCollection matchtext = rgx.Matches(text);
            if (matchtext.Count > 0) return true;
            else return false;
        }
    }
}