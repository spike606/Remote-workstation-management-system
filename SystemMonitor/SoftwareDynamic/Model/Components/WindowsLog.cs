using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.SoftwareDynamic.Model.Components.Interface;
using SystemMonitor.SoftwareDynamic.Provider;

namespace SystemMonitor.SoftwareDynamic.Model.Components
{
    public class WindowsLog : ISoftwareDynamicComponent<WindowsLog>
    {
        public EventLogEntryCollection Entries { get; private set; }

        public string LogName { get; private set; }

        public string LogDisplayName { get; private set; }

        public UnitValue MaximumKilobytes { get; private set; }

        public UnitValue MinimumRetentionDays { get; private set; }

        public List<WindowsLog> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider)
        {
            List<WindowsLog> windowsLogs = new List<WindowsLog>();
            var logs = softwareDynamicProvider.GetWindowsLogs();
            foreach (var log in logs)
            {
                WindowsLog windowsLog = new WindowsLog();
                windowsLog.Entries = log.Entries;
                windowsLog.LogName = log.Log;
                windowsLog.LogDisplayName = log.LogDisplayName;
                windowsLog.MaximumKilobytes = new UnitValue() { Unit = Unit.KB, Value = log.MaximumKilobytes.ToString() };
                windowsLog.MinimumRetentionDays = new UnitValue() { Unit = Unit.Days, Value = log.MinimumRetentionDays.ToString() };
                windowsLogs.Add(windowsLog);
            }

            return windowsLogs;
        }
    }
}
