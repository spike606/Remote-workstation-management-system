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
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.SoftwareDynamic.Provider
{
    public class SoftwareDynamicProvider : ISoftwareDynamicProvider
    {

        public SoftwareDynamicProvider(INLogger logger, IWMIClient wmiClient)
        {
            this.Logger = logger;
            this.WMIClient = wmiClient;
        }

        public INLogger Logger { get; set; }

        private IWMIClient WMIClient { get; set; }

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

        public ManagementObjectCollection GetWindowsProcessesFromWMI()
        {
            return this.WMIClient.GetObjectsFromWMI(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_PROCESS);
        }
    }
}
