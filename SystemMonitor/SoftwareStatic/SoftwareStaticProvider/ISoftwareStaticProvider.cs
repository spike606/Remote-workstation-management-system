using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;

namespace SystemMonitor.SoftwareStatic.SoftwareStaticProvider
{
    public interface ISoftwareStaticProvider
    {
        ServiceController[] GetAllWindowsServices();

        List<SoftwareStaticComponent> GetSoftwareStaticDataFromWMI(IWMISoftwareStaticComponent wmiComponent);
    }
}
