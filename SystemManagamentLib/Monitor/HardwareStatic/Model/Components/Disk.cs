using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
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
    [DataContract]
    public class Disk : HardwareStaticComponent, IHardwareStaticComponent<Disk>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830493(v=vs.85).aspx
        [DataMember]
        public UnitULongValue AllocatedSize { get; set; }

        [DataMember]
        public string BootFromDisk { get; set; }

        [DataMember]
        public string BusType { get; set; }

        [DataMember]
        public string FirmwareVersion { get; set; }

        [DataMember]
        public string FriendlyName { get; set; }

        [DataMember]
        public string HealthStatus { get; set; }

        [DataMember]
        public string IsBoot { get; set; }

        [DataMember]
        public string IsClustered { get; set; }

        [DataMember]
        public string IsOffline { get; set; }

        [DataMember]
        public string IsReadOnly { get; set; }

        [DataMember]
        public string IsSystem { get; set; }

        [DataMember]
        public UnitULongValue LargestFreeExtent { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public UnitUIntValue LogicalSectorSize { get; set; }

        [DataMember]
        public string Manufacturer { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string NumberOfPartitions { get; set; }

        [DataMember]
        public string ObjectId { get; set; }

        [DataMember]
        public string OfflineReason { get; set; }

        [DataMember]
        public string PartitionStyle { get; set; }

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public UnitUIntValue PhysicalSectorSize { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string Signature { get; set; }

        [DataMember]
        public UnitULongValue Size { get; set; }

        [DataMember]
        public string UniqueId { get; set; }

        public List<Disk> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<Disk> staticData = new List<Disk>();

            foreach (var managementObject in managementObjectList)
            {
                Disk disk = new Disk();
                disk.AllocatedSize = managementObject[ConstString.DISK_ALLOCATED_SIZE].TryGetUnitULongValue(Unit.B);
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
                disk.LargestFreeExtent = managementObject[ConstString.DISK_LARGEST_FREE_EXTEND].TryGetUnitULongValue(Unit.B);
                disk.Location = managementObject[ConstString.DISK_LOCATION].TryGetStringValue();
                disk.LogicalSectorSize = managementObject[ConstString.DISK_LOGICAL_SECTOR_SIZE].TryGetUnitUIntValue(Unit.B);
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

                disk.Size = managementObject[ConstString.DISK_SIZE].TryGetUnitULongValue(Unit.B);
                if (managementObject[ConstString.DISK_PARTITION_STYLE] != null)
                {
                    disk.PartitionStyle = ((PartitionStyleEnum)((ushort)managementObject[ConstString.DISK_PARTITION_STYLE])).GetEnumDescription();
                }
                else
                {
                    disk.PartitionStyle = string.Empty;
                }

                disk.Path = managementObject[ConstString.DISK_PATH].TryGetStringValue();
                disk.PhysicalSectorSize = managementObject[ConstString.DISK_PHYSICAL_SECTOR_SIZE].TryGetUnitUIntValue(Unit.B);
                disk.SerialNumber = managementObject[ConstString.DISK_SERIAL_NUMBER].TryGetStringValue();
                disk.Signature = managementObject[ConstString.DISK_SIGNATURE].TryGetStringValue();
                disk.Size = managementObject[ConstString.DISK_SIZE].TryGetUnitULongValue(Unit.B);
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
