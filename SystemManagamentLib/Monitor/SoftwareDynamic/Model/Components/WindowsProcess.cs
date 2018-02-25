using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareDynamic.Provider;

namespace SystemManagament.Monitor.SoftwareDynamic.Model.Components
{
    public class WindowsProcess : ISoftwareDynamicComponent<WindowsProcess>
    {
        public string BasePriority { get; internal set; }

        public string Id { get; internal set; }

        public string Name { get; internal set; }

        public DateTime StartTime { get; internal set; }

        public TimeSpan TotalProcessorTime { get; internal set; }

        public UnitValue PeakPagedMemorySize64 { get; internal set; }

        public UnitValue PeakVirtualMemorySize64 { get; internal set; }

        public UnitValue PeakMemorySize { get; internal set; }

        public string SessionId { get; internal set; }

        public UnitValue PagedMemorySize64 { get; internal set; }

        public UnitValue VirtualMemorySize64 { get; internal set; }

        public UnitValue MemorySize { get; internal set; }

        public string UserName { get; internal set; }

        public List<WindowsProcess> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider)
        {
            var windowsProcesses = softwareDynamicProvider.GetWindowsProcesses();

            return windowsProcesses;
        }
    }
}
