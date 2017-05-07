using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SystemMonitor.NLogger
{
    internal interface INLogger
    {
        void LogDebug(string message);
    }
}
