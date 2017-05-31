using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class LogicalDisk : IHardwareComponent
    {
        public UnitValue BlockSize { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string FileSystem { get; set; }

        public UnitValue FreeSpace { get; set; }

        public string Name { get; set; }

        public string ProviderName { get; set; }

        public UnitValue Size { get; set; }

        public string VolumeName { get; set; }

        public string VolumeSerialNumber { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            LogicalDisk logicalDisk = new LogicalDisk();
            logicalDisk.BlockSize = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.LOGICAL_DISK_BLOCK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.Caption = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_CAPTION]?.ToString() ?? string.Empty;
            logicalDisk.Description = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_DESCRIPTION]?.ToString() ?? string.Empty;
            logicalDisk.DeviceID = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_DEVICE_ID]?.ToString() ?? string.Empty;
            logicalDisk.FileSystem = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_FILE_SYSTEM]?.ToString() ?? string.Empty;
            logicalDisk.FreeSpace = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.LOGICAL_DISK_BLOCK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.Name = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_NAME]?.ToString() ?? string.Empty;
            logicalDisk.ProviderName = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_PROVIDER_NAME]?.ToString() ?? string.Empty;
            logicalDisk.Size = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.LOGICAL_DISK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.VolumeName = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_VOLUME_NAME]?.ToString() ?? string.Empty;
            logicalDisk.VolumeSerialNumber = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_VOLUME_SERIAL_NUMBER]?.ToString() ?? string.Empty;

            return logicalDisk;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_LOGICAL_DISK);
        }
    }
}
