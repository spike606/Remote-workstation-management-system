using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model
{
    public interface IHardwareComponent
    {
        List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient);

        IHardwareComponent ExtractData(ManagementObject managementObject);
    }
}
