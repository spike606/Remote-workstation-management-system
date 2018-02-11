using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.Logger;
using SystemMonitor.Shared.Win32API;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareDynamic.Model.Components;

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
                this.Logger.LogError(ex.Message, ex);
            }

            return new ServiceController[0];
        }

        public Process[] GetWindowsProcesses()
        {
            try
            {
                return Process.GetProcesses();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);
            }

            return new Process[0];
        }

        public string GetProcessOwner(Process process)
        {
            return this.Win32APIClient.GetProcessUser(process);
        }

        public List<WindowsLog> GetWindowsLogs()
        {
            List<WindowsLog> windowsLogs = new List<WindowsLog>();
            var logs = EventLog.GetEventLogs();
            foreach (var log in logs)
            {
                try
                {
                    WindowsLog windowsLog = new WindowsLog();
                    windowsLog.Entries = log.Entries;
                    windowsLog.LogName = log.Log;
                    windowsLog.LogDisplayName = log.LogDisplayName;
                    windowsLog.MaximumKilobytes = new UnitValue() { Unit = Unit.KB, Value = log.MaximumKilobytes.ToString() };
                    windowsLog.MinimumRetentionDays = new UnitValue() { Unit = Unit.Days, Value = log.MinimumRetentionDays.ToString() };
                    windowsLogs.Add(windowsLog);
                }
                catch (Exception ex)
                {
                    this.Logger.LogError(ex.Message, ex);
                }
            }

            return windowsLogs;
        }
    }
}
