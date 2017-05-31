using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class CDROMDrive : IHardwareComponent
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string Drive { get; set; }

        public string MediaType { get; set; }

        public string Name { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            CDROMDrive cdROMDrive = new CDROMDrive();
            cdROMDrive.Caption = managementObject[ConstStringHardwareStatic.CDROM_DRIVE_CAPTION]?.ToString() ?? string.Empty;
            cdROMDrive.Description = managementObject[ConstStringHardwareStatic.CDROM_DRIVE_DESCRIPTION]?.ToString() ?? string.Empty;
            cdROMDrive.DeviceID = managementObject[ConstStringHardwareStatic.CDROM_DRIVE_DEVICE_ID]?.ToString() ?? string.Empty;
            cdROMDrive.Drive = managementObject[ConstStringHardwareStatic.CDROM_DRIVE_DRIVE]?.ToString() ?? string.Empty;
            cdROMDrive.MediaType = managementObject[ConstStringHardwareStatic.CDROM_DRIVE_MEDIA_TYPE]?.ToString() ?? string.Empty;
            cdROMDrive.Name = managementObject[ConstStringHardwareStatic.CDROM_DRIVE_NAME]?.ToString() ?? string.Empty;

            return cdROMDrive;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_CDROM_DRIVE);
        }
    }
}
