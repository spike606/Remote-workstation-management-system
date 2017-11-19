using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.SoftwareDynamic.Model.Components.Interface;
using SystemMonitor.SoftwareDynamic.Provider;

namespace SystemMonitor.SoftwareDynamic.Model.Components
{
    public class WindowsProcess : ISoftwareDynamicComponent<WindowsProcess>
    {
        public string BasePriority { get; private set; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public DateTime StartTime { get; private set; }

        public TimeSpan TotalProcessorTime { get; private set; }

        public UnitValue PeakPagedMemorySize64 { get; private set; }

        public UnitValue PeakVirtualMemorySize64 { get; private set; }

        public UnitValue PeakMemorySize { get; private set; }

        public string SessionId { get; private set; }

        public UnitValue PagedMemorySize64 { get; private set; }

        public UnitValue VirtualMemorySize64 { get; private set; }

        public UnitValue MemorySize { get; private set; }

        public string UserName { get; private set; }

        public List<WindowsProcess> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider)
        {
            List<WindowsProcess> windowsProcesses = new List<WindowsProcess>();
            var processes = softwareDynamicProvider.GetWindowsProcesses();

            foreach (var process in processes)
            {
                try
                {
                    WindowsProcess windowsProcess = new WindowsProcess();
                    windowsProcess.BasePriority = process.BasePriority.ToString();
                    windowsProcess.Id = process.Id.ToString();
                    windowsProcess.Name = process.ProcessName;
                    windowsProcess.StartTime = process.StartTime;
                    windowsProcess.TotalProcessorTime = process.TotalProcessorTime;
                    windowsProcess.PagedMemorySize64 = new UnitValue() { Unit = Unit.B, Value = process.PagedMemorySize64.ToString() };
                    windowsProcess.VirtualMemorySize64 = new UnitValue() { Unit = Unit.B, Value = process.VirtualMemorySize64.ToString() };
                    windowsProcess.MemorySize = new UnitValue() { Unit = Unit.B, Value = process.WorkingSet64.ToString() };
                    windowsProcess.TotalProcessorTime = process.TotalProcessorTime;
                    windowsProcess.PeakPagedMemorySize64 = new UnitValue() { Unit = Unit.B, Value = process.PeakPagedMemorySize64.ToString() };
                    windowsProcess.PeakVirtualMemorySize64 = new UnitValue() { Unit = Unit.B, Value = process.PeakVirtualMemorySize64.ToString() };
                    windowsProcess.PeakMemorySize = new UnitValue() { Unit = Unit.B, Value = process.PeakWorkingSet64.ToString() };
                    windowsProcess.SessionId = process.SessionId.ToString();

                    var processOwner = softwareDynamicProvider.GetProcessOwner(process);
                    windowsProcess.UserName = processOwner.Contains(@"\") ? processOwner.Substring(processOwner.IndexOf(@"\") + 1) : processOwner;

                    windowsProcesses.Add(windowsProcess);
                }
                catch (Exception ex)
                {
                }
            }

            return windowsProcesses;
        }
    }
}
