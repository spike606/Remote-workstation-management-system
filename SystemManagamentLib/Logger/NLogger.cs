using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SystemManagament.Logger
{
    public class NLogger : INLogger
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message, Exception exception)
        {
            logger.Error(exception, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }
    }
}
