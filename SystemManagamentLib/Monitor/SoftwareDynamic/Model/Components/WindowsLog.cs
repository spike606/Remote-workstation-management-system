using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareDynamic.Provider;

namespace SystemManagament.Monitor.SoftwareDynamic.Model.Components
{
    public class WindowsLog : ISoftwareDynamicComponent<WindowsLog>
    {
        public EventLogEntryCollection Entries { get; internal set; }

        public string LogName { get; internal set; }

        public string LogDisplayName { get; internal set; }

        public UnitValue MaximumKilobytes { get; internal set; }

        public UnitValue MinimumRetentionDays { get; internal set; }

        public List<WindowsLog> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider)
        {
            return softwareDynamicProvider.GetWindowsLogs();
        }
    }
}
