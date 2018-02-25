using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components.Interface
{
    public interface IHardwareStaticComponent<T>
        where T : class
    {
        List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient);

        List<T> ExtractData(List<ManagementObject> managementObjectList);
    }
}
