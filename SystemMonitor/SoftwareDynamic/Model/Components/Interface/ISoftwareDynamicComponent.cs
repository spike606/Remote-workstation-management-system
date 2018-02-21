using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareDynamic.Provider;

namespace SystemMonitor.SoftwareDynamic.Model.Components.Interface
{
    public interface ISoftwareDynamicComponent<T>
    {
        List<T> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider);
    }
}
