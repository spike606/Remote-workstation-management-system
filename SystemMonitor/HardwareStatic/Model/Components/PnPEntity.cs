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
    public class PnPEntity : HardwareStaticComponent, IHardwareStaticComponent<PnPEntity>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394353(v=vs.85).aspx
        public string DeviceID { get; private set; }

        public string Manufacturer { get; private set; }

        public List<PnPEntity> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<PnPEntity> staticData = new List<PnPEntity>();

            foreach (var managementObject in managementObjectList)
            {
                PnPEntity pnPEntity = new PnPEntity();
                pnPEntity.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                pnPEntity.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                pnPEntity.DeviceID = managementObject[ConstString.PNP_ENTITY_DEVICE_ID].TryGetStringValue();
                pnPEntity.Manufacturer = managementObject[ConstString.PNP_ENTITY_MANUFACTURER].TryGetStringValue();
                pnPEntity.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                pnPEntity.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();

                staticData.Add(pnPEntity);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_PNP_ENTITY);
        }
    }
}
