using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.SoftwareDynamic.Provider
{
    public interface ISoftwareDynamicProvider
    {
        ServiceController[] GetWindowsServices();

        EventLog[] GetWindowsLogs();
    }
}
