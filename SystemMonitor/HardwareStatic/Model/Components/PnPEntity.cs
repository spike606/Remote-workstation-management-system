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
    public class PnPEntity : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394353(v=vs.85).aspx
        public string DeviceID { get; private set; }

        public string Manufacturer { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            PnPEntity pnPEntity = new PnPEntity();
            pnPEntity.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            pnPEntity.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            pnPEntity.DeviceID = managementObject[ConstStringHardwareStatic.PNP_ENTITY_DEVICE_ID]?.ToString() ?? string.Empty;
            pnPEntity.Manufacturer = managementObject[ConstStringHardwareStatic.PNP_ENTITY_MANUFACTURER]?.ToString() ?? string.Empty;
            pnPEntity.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            pnPEntity.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;

            return pnPEntity;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_PNP_ENTITY);
        }
    }
}
