using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class BaseBoardStaticComparer : IEqualityComparer<BaseBoard>
    {
        public bool Equals(BaseBoard x, BaseBoard y)
        {
            return x.Product == y.Product
                && x.Caption == y.Caption
                && x.Description == y.Description
                && x.Name == y.Name
                && x.Manufacturer == y.Manufacturer
                && x.PartNumber == y.PartNumber
                && x.SerialNumber == y.SerialNumber
                && x.Status == y.Status
                && x.Model == y.Model
                && x.Version == y.Version;
        }

        public int GetHashCode(BaseBoard obj)
        {
            return obj.GetHashCode();
        }
    }
}
