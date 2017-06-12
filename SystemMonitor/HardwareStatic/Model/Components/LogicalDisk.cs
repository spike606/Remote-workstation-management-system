using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class LogicalDisk : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394173(v=vs.85).aspx
        public UnitValue BlockSize { get; private set; }

        public string DeviceID { get; private set; }

        public string FileSystem { get; private set; }

        public UnitValue FreeSpace { get; private set; }

        public string ProviderName { get; private set; }

        public UnitValue Size { get; private set; }

        public string VolumeName { get; private set; }

        public string VolumeSerialNumber { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            LogicalDisk logicalDisk = new LogicalDisk();
            logicalDisk.BlockSize = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.LOGICAL_DISK_BLOCK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            logicalDisk.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            logicalDisk.DeviceID = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_DEVICE_ID]?.ToString() ?? string.Empty;
            logicalDisk.FileSystem = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_FILE_SYSTEM]?.ToString() ?? string.Empty;
            logicalDisk.FreeSpace = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.LOGICAL_DISK_BLOCK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            logicalDisk.ProviderName = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_PROVIDER_NAME]?.ToString() ?? string.Empty;
            logicalDisk.Size = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.LOGICAL_DISK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            logicalDisk.VolumeName = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_VOLUME_NAME]?.ToString() ?? string.Empty;
            logicalDisk.VolumeSerialNumber = managementObject[ConstStringHardwareStatic.LOGICAL_DISK_VOLUME_SERIAL_NUMBER]?.ToString() ?? string.Empty;

            return logicalDisk;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_LOGICAL_DISK);
        }
    }
}
