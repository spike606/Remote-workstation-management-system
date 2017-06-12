using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Volume : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394515(v=vs.85).aspx
        public UnitValue BlockSize { get; private set; }

        public string BootVolume { get; private set; }

        public UnitValue Capacity { get; private set; }

        public string DeviceID { get; private set; }

        public string DriveLetter { get; private set; }

        public string DriveType { get; private set; }

        public string FileSystem { get; private set; }

        public UnitValue FreeSpace { get; private set; }

        public string Label { get; private set; }

        public string SerialNumber { get; private set; }

        public string SystemVolume { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            Volume volume = new Volume();
            volume.BlockSize = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.VOLUME_BLOCK_SIZE]?.ToString() ?? string.Empty);
            volume.BootVolume = managementObject[ConstStringHardwareStatic.VOLUME_BOOT_VOLUME]?.ToString() ?? string.Empty;
            volume.Capacity = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.VOLUME_CAPACITY]?.ToString() ?? string.Empty);
            volume.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            volume.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
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
            volume.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            volume.SerialNumber = managementObject[ConstStringHardwareStatic.VOLUME_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            volume.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            volume.SystemVolume = managementObject[ConstStringHardwareStatic.VOLUME_SYSTEM_VOLUME]?.ToString() ?? string.Empty;

            return volume;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_VOLUME);
        }
    }
}
