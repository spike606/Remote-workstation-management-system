using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Disk : HardwareStaticComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830493(v=vs.85).aspx
        public UnitValue AllocatedSize { get; private set; }

        public string BootFromDisk { get; private set; }

        public string BusType { get; private set; }

        public string FirmwareVersion { get; private set; }

        public string FriendlyName { get; private set; }

        public string HealthStatus { get; private set; }

        public string IsBoot { get; private set; }

        public string IsClustered { get; private set; }

        public string IsOffline { get; private set; }

        public string IsReadOnly { get; private set; }

        public string IsSystem { get; private set; }

        public UnitValue LargestFreeExtent { get; private set; }

        public string Location { get; private set; }

        public UnitValue LogicalSectorSize { get; private set; }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public string Number { get; private set; }

        public string NumberOfPartitions { get; private set; }

        public string ObjectId { get; private set; }

        public string OfflineReason { get; private set; }

        public string PartitionStyle { get; private set; }

        public string Path { get; private set; }

        public UnitValue PhysicalSectorSize { get; private set; }

        public string SerialNumber { get; private set; }

        public string Signature { get; private set; }

        public UnitValue Size { get; private set; }

        public string UniqueId { get; private set; }

        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            Disk disk = new Disk();
            disk.AllocatedSize = new UnitValue(Unit.B, managementObject[ConstString.DISK_ALLOCATED_SIZE]?.ToString() ?? string.Empty);
            disk.BootFromDisk = managementObject[ConstString.DISK_BOOT_FROM_DISK]?.ToString() ?? string.Empty;
            if (managementObject[ConstString.DISK_BUS_TYPE] != null)
            {
                disk.BusType = ((BusTypeEnum)((ushort)managementObject[ConstString.DISK_BUS_TYPE])).GetEnumDescription();
            }
            else
            {
                disk.BusType = string.Empty;
            }

            disk.Caption = string.Empty;
            disk.Description = string.Empty;
            disk.FirmwareVersion = managementObject[ConstString.DISK_FIRMWARE_VERSION]?.ToString() ?? string.Empty;
            disk.FriendlyName = managementObject[ConstString.DISK_FRIENDLY_NAME]?.ToString() ?? string.Empty;

            if (managementObject[ConstString.DISK_HEALTH_STATUS] != null)
            {
                disk.HealthStatus = ((HealthStatusDiskEnum)((ushort)managementObject[ConstString.DISK_HEALTH_STATUS])).GetEnumDescription();
            }
            else
            {
                disk.HealthStatus = string.Empty;
            }

            disk.IsBoot = managementObject[ConstString.DISK_IS_BOOT]?.ToString() ?? string.Empty;
            disk.IsClustered = managementObject[ConstString.DISK_IS_CLUSTERED]?.ToString() ?? string.Empty;
            disk.IsOffline = managementObject[ConstString.DISK_IS_OFFILINE]?.ToString() ?? string.Empty;
            disk.IsReadOnly = managementObject[ConstString.DISK_IS_READONLY]?.ToString() ?? string.Empty;
            disk.IsSystem = managementObject[ConstString.DISK_IS_SYSTEM]?.ToString() ?? string.Empty;
            disk.LargestFreeExtent = new UnitValue(Unit.B, managementObject[ConstString.DISK_LARGEST_FREE_EXTEND]?.ToString() ?? string.Empty);
            disk.Location = managementObject[ConstString.DISK_LOCATION]?.ToString() ?? string.Empty;
            disk.LogicalSectorSize = new UnitValue(Unit.B, managementObject[ConstString.DISK_LOGICAL_SECTOR_SIZE]?.ToString() ?? string.Empty);
            disk.Manufacturer = managementObject[ConstString.DISK_MANUFACTURER]?.ToString() ?? string.Empty;
            disk.Model = managementObject[ConstString.DISK_MODEL]?.ToString() ?? string.Empty;
            disk.Name = string.Empty;
            disk.Number = managementObject[ConstString.DISK_NUMBER]?.ToString() ?? string.Empty;
            disk.NumberOfPartitions = managementObject[ConstString.DISK_NUMBER_OF_PARTITIONS]?.ToString() ?? string.Empty;
            disk.ObjectId = managementObject[ConstString.DISK_OBJECT_ID]?.ToString() ?? string.Empty;
            if (managementObject[ConstString.DISK_OFFLINE_REASON] != null)
            {
                disk.OfflineReason = ((OfflineReasonEnum)((ushort)managementObject[ConstString.DISK_OFFLINE_REASON])).GetEnumDescription();
            }
            else
            {
                disk.OfflineReason = string.Empty;
            }

            disk.Size = new UnitValue(Unit.B, managementObject[ConstString.DISK_SIZE]?.ToString() ?? string.Empty);
            if (managementObject[ConstString.DISK_PARTITION_STYLE] != null)
            {
                disk.PartitionStyle = ((PartitionStyleEnum)((ushort)managementObject[ConstString.DISK_PARTITION_STYLE])).GetEnumDescription();
            }
            else
            {
                disk.PartitionStyle = string.Empty;
            }

            disk.Path = managementObject[ConstString.DISK_PATH]?.ToString() ?? string.Empty;
            disk.PhysicalSectorSize = new UnitValue(Unit.B, managementObject[ConstString.DISK_PHYSICAL_SECTOR_SIZE]?.ToString() ?? string.Empty);
            disk.SerialNumber = managementObject[ConstString.DISK_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            disk.Signature = managementObject[ConstString.DISK_SIGNATURE]?.ToString() ?? string.Empty;
            disk.Size = new UnitValue(Unit.B, managementObject[ConstString.DISK_SIZE]?.ToString() ?? string.Empty);
            disk.Status = string.Empty;
            disk.UniqueId = managementObject[ConstString.DISK_UNIQUE_ID]?.ToString() ?? string.Empty;

            return disk;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstString.WMI_QUERY_DISK);
        }
    }
}
