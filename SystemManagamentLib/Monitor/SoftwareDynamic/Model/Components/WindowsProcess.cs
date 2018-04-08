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
        public string BasePriority { get; internal set; }

        [DataMember]
        public string Id { get; internal set; }

        [DataMember]
        public string Name { get; internal set; }

        [DataMember]
        public DateTime StartTime { get; internal set; }

        [DataMember]
        public TimeSpan TotalProcessorTime { get; internal set; }

        [DataMember]
        public UnitValue PeakPagedMemorySize64 { get; internal set; }

        [DataMember]
        public UnitValue PeakVirtualMemorySize64 { get; internal set; }

        [DataMember]
        public UnitValue PeakMemorySize { get; internal set; }

        [DataMember]
        public string SessionId { get; internal set; }

        [DataMember]
        public UnitValue PagedMemorySize64 { get; internal set; }

        [DataMember]
        public UnitValue VirtualMemorySize64 { get; internal set; }

        [DataMember]
        public UnitValue MemorySize { get; internal set; }

        [DataMember]
        public string UserName { get; internal set; }

        public List<WindowsProcess> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider)
        {
            var windowsProcesses = softwareDynamicProvider.GetWindowsProcesses();

            return windowsProcesses;
        }
    }
}
