using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class LogCreate
    {
        [Obsolete]
        public static void Logger(Exception exp) 
        {
            Logger logger= LogManager.GetCurrentClassLogger();
            logger.ErrorException("Komunikat", exp);
        }
    }
}