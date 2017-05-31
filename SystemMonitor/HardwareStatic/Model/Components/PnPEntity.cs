using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class PnPEntity : IHardwareComponent
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string Manufacturer { get; set; }

        public string Name { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            PnPEntity pnPEntity = new PnPEntity();
            pnPEntity.Caption = managementObject[ConstStringHardwareStatic.PNP_ENTITY_CAPTION]?.ToString() ?? string.Empty;
            pnPEntity.Description = managementObject[ConstStringHardwareStatic.PNP_ENTITY_DESCRIPTION]?.ToString() ?? string.Empty;
            pnPEntity.DeviceID = managementObject[ConstStringHardwareStatic.PNP_ENTITY_DEVICE_ID]?.ToString() ?? string.Empty;
            pnPEntity.Manufacturer = managementObject[ConstStringHardwareStatic.PNP_ENTITY_MANUFACTURER]?.ToString() ?? string.Empty;
            pnPEntity.Name = managementObject[ConstStringHardwareStatic.PNP_ENTITY_NAME]?.ToString() ?? string.Empty;

            return pnPEntity;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_PNP_ENTITY);
        }
    }
}
