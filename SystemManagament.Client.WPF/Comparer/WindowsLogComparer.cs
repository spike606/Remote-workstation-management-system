using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class WindowsLogComparer : IEqualityComparer<WindowsLog>
    {
        public bool Equals(WindowsLog x, WindowsLog y)
        {
            return x.LogDisplayName == y.LogDisplayName
                && x.LogName == y.LogName
                && x.MaximumKilobytes.Value == y.MaximumKilobytes.Value
                && x.MinimumRetentionDays.Value == y.MinimumRetentionDays.Value;
        }

        public int GetHashCode(WindowsLog obj)
        {
            return obj.GetHashCode();
        }
    }
}
