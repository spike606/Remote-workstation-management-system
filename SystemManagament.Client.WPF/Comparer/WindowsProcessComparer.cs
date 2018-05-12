using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.Comparer
{
    public class WindowsProcessComparer : IEqualityComparer<WindowsProcess>
    {
        public bool Equals(WindowsProcess x, WindowsProcess y)
        {
            return x.Id == y.Id
                && x.BasePriority == y.BasePriority
                && x.Name == y.Name
                && x.SessionId == y.SessionId
                && x.StartTime == y.StartTime
                && x.TotalProcessorTime == y.TotalProcessorTime
                && x.UserName == x.UserName
                && x.VirtualMemorySize64.Value == y.VirtualMemorySize64.Value
                && x.PeakVirtualMemorySize64.Value == y.PeakVirtualMemorySize64.Value
                && x.PeakPagedMemorySize64.Value == y.PeakPagedMemorySize64.Value
                && x.PeakMemorySize.Value == y.PeakMemorySize.Value
                && x.PagedMemorySize64.Value == y.PagedMemorySize64.Value
                && x.MemorySize.Value == y.MemorySize.Value;
        }

        public int GetHashCode(WindowsProcess obj)
        {
            return obj.GetHashCode();
        }
    }
}
