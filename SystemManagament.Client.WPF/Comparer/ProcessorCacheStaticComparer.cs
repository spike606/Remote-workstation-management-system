using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class ProcessorCacheStaticComparer : IEqualityComparer<ProcessorCache>
    {
        public bool Equals(ProcessorCache x, ProcessorCache y)
        {
            return x.Caption == y.Caption
                && x.Description == y.Description
                && x.Level == y.Level
                && x.Name == y.Name
                && x.Size.Value == y.Size.Value
                && x.Speed.Value == y.Speed.Value
                && x.Status == y.Status;
        }

        public int GetHashCode(ProcessorCache obj)
        {
            return obj.GetHashCode();
        }
    }
}
