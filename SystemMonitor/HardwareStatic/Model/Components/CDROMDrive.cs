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
    public class CDROMDrive : HardwareStaticComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394081(v=vs.85).aspx
        public string DeviceID { get; private set; }

        public string Drive { get; private set; }

        public string MediaType { get; private set; }

        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            CDROMDrive cdROMDrive = new CDROMDrive();
            cdROMDrive.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            cdROMDrive.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            cdROMDrive.DeviceID = managementObject[ConstString.CDROM_DRIVE_DEVICE_ID]?.ToString() ?? string.Empty;
            cdROMDrive.Drive = managementObject[ConstString.CDROM_DRIVE_DRIVE]?.ToString() ?? string.Empty;
            cdROMDrive.MediaType = managementObject[ConstString.CDROM_DRIVE_MEDIA_TYPE]?.ToString() ?? string.Empty;
            cdROMDrive.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            cdROMDrive.Status = managementObject[ConstString.COMPONENT_STATUS]?.ToString() ?? string.Empty;

            return cdROMDrive;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_CDROM_DRIVE);
        }
    }
}
