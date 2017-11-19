using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SystemMonitor.NLogger
{
    internal class NLogger : INLogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public void LogError(string message)
        {
            logger.Log(LogLevel.Error, message);
        }
    }
}
