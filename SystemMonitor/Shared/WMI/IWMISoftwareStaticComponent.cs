using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;

namespace SystemMonitor.Shared.WMI
{
    public interface IWMISoftwareStaticComponent
    {
        List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient);

        SoftwareStaticComponent ExtractData(ManagementObject managementObject);
    }
}
