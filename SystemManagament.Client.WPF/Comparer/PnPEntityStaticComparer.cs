using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class PnPEntityStaticComparer : IEqualityComparer<PnPEntity>
    {
        public bool Equals(PnPEntity x, PnPEntity y)
        {
            return x.Caption == y.Caption
                && x.Description == y.Description
                && x.Name == y.Name
                && x.Status == y.Status
                && x.DeviceID == y.DeviceID
                && x.Manufacturer == y.Manufacturer;
        }

        public int GetHashCode(PnPEntity obj)
        {
            return obj.GetHashCode();
        }
    }
}
