using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.SoftwareDynamic.Provider
{
    public class SoftwareDynamicProvider : ISoftwareDynamicProvider
    {
        public ServiceController[] GetWindowsServices()
        {
            return ServiceController.GetServices();
        }

        public EventLog[] GetWindowsLogs()
        {
            return EventLog.GetEventLogs();
        }
    }
}
