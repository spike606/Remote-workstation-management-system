using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class PrinterStaticComparer : IEqualityComparer<Printer>
    {
        public bool Equals(Printer x, Printer y)
        {
            return x.Caption == y.Caption
                && x.Description == y.Description
                && x.Name == y.Name
                && x.Status == y.Status
                && x.AveragePagesPerMinute == y.AveragePagesPerMinute
                && x.Default == y.Default
                && x.DeviceID == y.DeviceID
                && x.PortName == y.PortName
                && x.PrintProcessor == y.PrintProcessor;
        }

        public int GetHashCode(Printer obj)
        {
            return obj.GetHashCode();
        }
    }
}
