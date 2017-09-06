using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Interface;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Fan : HardwareStaticComponent, IHardwareStaticComponent<Fan>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394146(v=vs.85).aspx
        public List<Fan> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<Fan> staticData = new List<Fan>();

            foreach (var managementObject in managementObjectList)
            {
                Fan fan = new Fan();
                fan.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
                fan.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
                fan.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;

                staticData.Add(fan);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_FAN);
        }
    }
}
