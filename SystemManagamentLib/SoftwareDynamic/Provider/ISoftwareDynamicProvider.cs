using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareDynamic.Model.Components;

namespace SystemMonitor.SoftwareDynamic.Provider
{
    public interface ISoftwareDynamicProvider
    {
        ServiceController[] GetWindowsServices();

        List<WindowsLog> GetWindowsLogs();

        List<WindowsProcess> GetWindowsProcesses();
    }
}
