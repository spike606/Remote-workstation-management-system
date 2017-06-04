using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Fan : HardwareComponent
    {
        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            Fan fan = new Fan();
            fan.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            fan.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            fan.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;

            return fan;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_FAN);
        }
    }
}
