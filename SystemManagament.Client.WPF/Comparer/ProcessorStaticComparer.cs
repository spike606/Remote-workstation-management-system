using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class ProcessorStaticComparer : IEqualityComparer<ProcessorStatic>
    {
        public bool Equals(ProcessorStatic x, ProcessorStatic y)
        {
            return x.AddressWidth.Value == y.AddressWidth.Value
                && x.Architecture == y.Architecture
                && x.BusSpeed.Value == y.BusSpeed.Value
                && x.Caption == y.Caption
                && x.DataWidth.Value == y.DataWidth.Value
                && x.Description == y.Description
                && x.Manufacturer == y.Manufacturer
                && x.MaxClockSpeed.Value == y.MaxClockSpeed.Value
                && x.Name == y.Name
                && x.NumberOfCores == y.NumberOfCores
                && x.NumberOfLogicalProcessors == y.NumberOfLogicalProcessors
                && x.ProcessorID == y.ProcessorID
                && x.SerialNumber == y.SerialNumber
                && x.SocketDesignation == y.SocketDesignation
                && x.Status == y.Status
                && x.Stepping == y.Stepping
                && x.ThreadCount == y.ThreadCount
                && x.UniqueId == y.UniqueId;
        }

        public int GetHashCode(ProcessorStatic obj)
        {
            return obj.GetHashCode();
        }
    }
}
