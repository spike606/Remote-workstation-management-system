using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.Shared.WMI
{
    public interface IWMISoftwareStaticComponent<T>
    {
        List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient);

        T ExtractData(ManagementObject managementObject);
    }
}
