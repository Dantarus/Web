
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp7.Manager
{ 
    public class LogCreate
    {

        public static void Logger(string text)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info(text);
        }
    }
}