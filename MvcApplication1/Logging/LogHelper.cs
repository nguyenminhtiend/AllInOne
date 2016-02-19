using log4net;
using System;

namespace MvcApplication1.Logging
{
    public class LogHelper
    {
        public static void Log(string message, Exception ex)
        {
            ILog loggerManager = LogManager.GetLogger("ABC");
            loggerManager.Error(message, ex);
        }
    }
}