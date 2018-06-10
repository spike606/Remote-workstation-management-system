using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class BatteryStaticComparer : IEqualityComparer<Battery>
    {
        public bool Equals(Battery x, Battery y)
        {
            return x.Caption == y.Caption
                && x.Description == y.Description
                && x.Name == y.Name
                && x.Status == y.Status
                && x.BatteryStatus == y.BatteryStatus
                && x.DesignCapacity.Value == y.DesignCapacity.Value
                && x.FullChargeCapacity.Value == y.FullChargeCapacity.Value
                && x.DeviceID == y.DeviceID;
        }

        public int GetHashCode(Battery obj)
        {
            return obj.GetHashCode();
        }
    }
}
