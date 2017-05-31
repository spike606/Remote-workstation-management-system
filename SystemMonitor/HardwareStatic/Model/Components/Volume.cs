using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Volume : IHardwareComponent
    {
        public UnitValue BlockSize { get; set; }

        public string BootVolume { get; set; }

        public UnitValue Capacity { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string DriveLetter { get; set; }

        public string DriveType { get; set; }

        public string FileSystem { get; set; }

        public UnitValue FreeSpace { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string Status { get; set; }

        public string SystemVolume { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            Volume volume = new Volume();
            volume.BlockSize = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.VOLUME_BLOCK_SIZE]?.ToString() ?? string.Empty);
            volume.BootVolume = managementObject[ConstStringHardwareStatic.VOLUME_BOOT_VOLUME]?.ToString() ?? string.Empty;
            volume.Capacity = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.VOLUME_CAPACITY]?.ToString() ?? string.Empty);
            volume.Caption = managementObject[ConstStringHardwareStatic.VOLUME_CAPTION]?.ToString() ?? string.Empty;
            volume.Description = managementObject[ConstStringHardwareStatic.VOLUME_DESCRIPTION]?.ToString() ?? string.Empty;
            volume.DeviceID = managementObject[ConstStringHardwareStatic.VOLUME_DEVICE_ID]?.ToString() ?? string.Empty;
            volume.DriveLetter = managementObject[ConstStringHardwareStatic.VOLUME_DRIVE_LETTER]?.ToString() ?? string.Empty;

            if (managementObject[ConstStringHardwareStatic.VOLUME_DRIVE_TYPE] != null)
            {
                volume.DriveType = ((DriveTypeEnum)((uint)managementObject[ConstStringHardwareStatic.VOLUME_DRIVE_TYPE])).ToString();
            }
            else
            {
                volume.DriveType = string.Empty;
            }

            volume.FileSystem = managementObject[ConstStringHardwareStatic.VOLUME_FILE_SYSTEM]?.ToString() ?? string.Empty;
            volume.FreeSpace = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.VOLUME_FREE_SPACE]?.ToString() ?? string.Empty);
            volume.Label = managementObject[ConstStringHardwareStatic.VOLUME_LABEL]?.ToString() ?? string.Empty;
            volume.Name = managementObject[ConstStringHardwareStatic.VOLUME_NAME]?.ToString() ?? string.Empty;
            volume.SerialNumber = managementObject[ConstStringHardwareStatic.VOLUME_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            volume.Status = managementObject[ConstStringHardwareStatic.VOLUME_STATUS]?.ToString() ?? string.Empty;
            volume.SystemVolume = managementObject[ConstStringHardwareStatic.VOLUME_SYSTEM_VOLUME]?.ToString() ?? string.Empty;

            return volume;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_VOLUME);
        }
    }
}
