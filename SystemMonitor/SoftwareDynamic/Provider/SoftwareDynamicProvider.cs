using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.NLogger;
using SystemMonitor.Shared.Win32API;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.SoftwareDynamic.Provider
{
    public class SoftwareDynamicProvider : ISoftwareDynamicProvider
    {

        public SoftwareDynamicProvider(INLogger logger, IWin32APIClient win32APIClient)
        {
            this.Logger = logger;
            this.Win32APIClient = win32APIClient;
        }

        public INLogger Logger { get; set; }

        private IWin32APIClient Win32APIClient { get; set; }

        public ServiceController[] GetWindowsServices()
        {
            try
            {
                return ServiceController.GetServices();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
            }

            return new ServiceController[0];
        }

        public EventLog[] GetWindowsLogs()
        {
            return EventLog.GetEventLogs();
        }

        public Process[] GetWindowsProcesses()
        {
            try
            {
                return Process.GetProcesses();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
            }

            return new Process[0];
        }

        public string GetProcessOwner(Process process)
        {
            return this.Win32APIClient.GetProcessUser(process);
        }
    }
}
