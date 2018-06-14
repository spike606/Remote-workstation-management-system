using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareDynamic.Provider;

namespace SystemManagament.Monitor.SoftwareDynamic.Model.Components
{
    [DataContract]
    public class WindowsProcess : ISoftwareDynamicComponent<WindowsProcess>
    {
        [DataMember]
        public int BasePriority { get; internal set; }

        [DataMember]
        public int Id { get; internal set; }

        [DataMember]
        public string Name { get; internal set; }

        [DataMember]
        public DateTime StartTime { get; internal set; }

        [DataMember]
        public TimeSpan TotalProcessorTime { get; internal set; }

        [DataMember]
        public UnitLongValue PeakPagedMemorySize { get; internal set; }

        [DataMember]
        public UnitLongValue PeakVirtualMemorySize { get; internal set; }

        [DataMember]
        public string SessionId { get; internal set; }

        [DataMember]
        public UnitLongValue PagedMemorySize { get; internal set; }

        [DataMember]
        public UnitLongValue NonPagedMemorySize { get; internal set; }

        [DataMember]
        public UnitLongValue VirtualMemorySize { get; internal set; }

        [DataMember]
        public UnitLongValue MemorySize { get; internal set; }

        [DataMember]
        public UnitLongValue PeakMemorySize { get; internal set; }

        [DataMember]
        public string UserName { get; internal set; }

        public List<WindowsProcess> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider)
        {
            var windowsProcesses = softwareDynamicProvider.GetWindowsProcesses();

            return windowsProcesses;
        }
    }
}
