using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class FanStaticComparer : IEqualityComparer<Fan>
    {
        public bool Equals(Fan x, Fan y)
        {
            return x.Caption == y.Caption
                && x.Description == y.Description
                && x.Name == y.Name
                && x.Status == y.Status;
        }

        public int GetHashCode(Fan obj)
        {
            return obj.GetHashCode();
        }
    }
}
