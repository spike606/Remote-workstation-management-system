using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.Comparer
{
    public class WindowsServiceComparer : IEqualityComparer<WindowsService>
    {
        public bool Equals(WindowsService x, WindowsService y)
        {
            return x.CanPauseAndContinue == y.CanPauseAndContinue
                && x.CanShutdown == y.CanShutdown
                && x.CanStop == y.CanStop
                && x.DisplayName == y.DisplayName
                && x.ServiceName == y.ServiceName
                && x.ServiceType == y.ServiceType
                && x.StartType == y.StartType
                && x.Status == y.Status;
        }

        public int GetHashCode(WindowsService obj)
        {
            return obj.GetHashCode();
        }
    }
}
