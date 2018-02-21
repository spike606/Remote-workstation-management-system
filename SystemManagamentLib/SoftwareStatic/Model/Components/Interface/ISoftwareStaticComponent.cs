using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Provider;

namespace SystemMonitor.SoftwareStatic.Model.Components.Interface
{
    public interface ISoftwareStaticComponent<T>
    {
        List<T> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider);
    }
}
