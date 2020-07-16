using log4net;
using log4net.Repository.Hierarchy;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
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