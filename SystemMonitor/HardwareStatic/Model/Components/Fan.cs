using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Fan : IHardwareComponent
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            Fan fan = new Fan();
            fan.Caption = managementObject[ConstStringHardwareStatic.FAN_CAPTION]?.ToString() ?? string.Empty;
            fan.Description = managementObject[ConstStringHardwareStatic.FAN_DESCRIPTION]?.ToString() ?? string.Empty;
            fan.Name = managementObject[ConstStringHardwareStatic.FAN_NAME]?.ToString() ?? string.Empty;

            return fan;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_FAN);
        }
    }
}
