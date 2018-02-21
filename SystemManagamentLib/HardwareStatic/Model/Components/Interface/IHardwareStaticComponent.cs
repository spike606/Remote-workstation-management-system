using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components.Interface
{
    public interface IHardwareStaticComponent<T>
        where T : class
    {
        List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient);

        List<T> ExtractData(List<ManagementObject> managementObjectList);
    }
}
