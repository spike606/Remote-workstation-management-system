using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class CDROMDriveStaticComparer : IEqualityComparer<CDROMDrive>
    {
        public bool Equals(CDROMDrive x, CDROMDrive y)
        {
            return x.Caption == y.Caption
                && x.Description == y.Description
                && x.Name == y.Name
                && x.Status == y.Status
                && x.Drive == y.Drive
                && x.MediaType == y.MediaType
                && x.DeviceID == y.DeviceID;
        }

        public int GetHashCode(CDROMDrive obj)
        {
            return obj.GetHashCode();
        }
    }
}
