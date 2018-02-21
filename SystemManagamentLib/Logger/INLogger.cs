using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SystemMonitor.Logger
{
    public interface INLogger
    {
        void LogDebug(string message);

        void LogError(string message, Exception exception);

        void LogInfo(string message);
    }
}
