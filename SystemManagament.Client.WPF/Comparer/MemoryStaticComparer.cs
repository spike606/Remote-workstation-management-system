using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class MemoryStaticComparer : IEqualityComparer<Memory>
    {
        public bool Equals(Memory x, Memory y)
        {
            return x.BankLabel == y.BankLabel
                && x.Capacity.Value == y.Capacity.Value
                && x.Caption == y.Caption
                && x.ConfiguredClockSpeed.Value == y.ConfiguredClockSpeed.Value
                && x.ConfiguredVoltage.Value == y.ConfiguredVoltage.Value
                && x.DataWidth.Value == y.DataWidth.Value
                && x.Description == y.Description
                && x.Name == y.Name
                && x.DeviceLocator == y.DeviceLocator
                && x.Manufacturer == y.Manufacturer
                && x.MaxVoltage.Value == y.MaxVoltage.Value
                && x.MemoryType == y.MemoryType
                && x.MinVoltage.Value == y.MinVoltage.Value
                && x.PartNumber == y.PartNumber
                && x.SerialNumber == y.SerialNumber
                && x.Status == y.Status
                && x.TotalWidth.Value == y.TotalWidth.Value;
        }

        public int GetHashCode(Memory obj)
        {
            return obj.GetHashCode();
        }
    }
}
