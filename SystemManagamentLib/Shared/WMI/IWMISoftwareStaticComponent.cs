using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Shared.WMI
{
    public interface IWMISoftwareStaticComponent<T>
    {
        List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient);

        T ExtractData(ManagementObject managementObject);
    }
}
