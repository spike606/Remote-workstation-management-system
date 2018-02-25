using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    public class Disk : HardwareStaticComponent, IHardwareStaticComponent<Disk>
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

        public List<Disk> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<Disk> staticData = new List<Disk>();

            foreach (var managementObject in managementObjectList)
            {
                Disk disk = new Disk();
                disk.AllocatedSize = managementObject[ConstString.DISK_ALLOCATED_SIZE].TryGetUnitValue(Unit.B);
                disk.BootFromDisk = managementObject[ConstString.DISK_BOOT_FROM_DISK].TryGetStringValue();
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
                disk.FirmwareVersion = managementObject[ConstString.DISK_FIRMWARE_VERSION].TryGetStringValue();
                disk.FriendlyName = managementObject[ConstString.DISK_FRIENDLY_NAME].TryGetStringValue();

                if (managementObject[ConstString.DISK_HEALTH_STATUS] != null)
                {
                    disk.HealthStatus = ((HealthStatusDiskEnum)((ushort)managementObject[ConstString.DISK_HEALTH_STATUS])).GetEnumDescription();
                }
                else
                {
                    disk.HealthStatus = string.Empty;
                }

                disk.IsBoot = managementObject[ConstString.DISK_IS_BOOT].TryGetStringValue();
                disk.IsClustered = managementObject[ConstString.DISK_IS_CLUSTERED].TryGetStringValue();
                disk.IsOffline = managementObject[ConstString.DISK_IS_OFFILINE].TryGetStringValue();
                disk.IsReadOnly = managementObject[ConstString.DISK_IS_READONLY].TryGetStringValue();
                disk.IsSystem = managementObject[ConstString.DISK_IS_SYSTEM].TryGetStringValue();
                disk.LargestFreeExtent = managementObject[ConstString.DISK_LARGEST_FREE_EXTEND].TryGetUnitValue(Unit.B);
                disk.Location = managementObject[ConstString.DISK_LOCATION].TryGetStringValue();
                disk.LogicalSectorSize = managementObject[ConstString.DISK_LOGICAL_SECTOR_SIZE].TryGetUnitValue(Unit.B);
                disk.Manufacturer = managementObject[ConstString.DISK_MANUFACTURER].TryGetStringValue();
                disk.Model = managementObject[ConstString.DISK_MODEL].TryGetStringValue();
                disk.Name = string.Empty;
                disk.Number = managementObject[ConstString.DISK_NUMBER].TryGetStringValue();
                disk.NumberOfPartitions = managementObject[ConstString.DISK_NUMBER_OF_PARTITIONS].TryGetStringValue();
                disk.ObjectId = managementObject[ConstString.DISK_OBJECT_ID].TryGetStringValue();
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

                disk.Path = managementObject[ConstString.DISK_PATH].TryGetStringValue();
                disk.PhysicalSectorSize = managementObject[ConstString.DISK_PHYSICAL_SECTOR_SIZE].TryGetUnitValue(Unit.B);
                disk.SerialNumber = managementObject[ConstString.DISK_SERIAL_NUMBER].TryGetStringValue();
                disk.Signature = managementObject[ConstString.DISK_SIGNATURE].TryGetStringValue();
                disk.Size = managementObject[ConstString.DISK_SIZE].TryGetUnitValue(Unit.B);
                disk.Status = string.Empty;
                disk.UniqueId = managementObject[ConstString.DISK_UNIQUE_ID].TryGetStringValue();

                staticData.Add(disk);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstString.WMI_QUERY_DISK);
        }
    }
}
