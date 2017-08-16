using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Fan : HardwareStaticComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394146(v=vs.85).aspx
        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            Fan fan = new Fan();
            fan.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            fan.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            fan.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;

            return fan;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_FAN);
        }
    }
}
