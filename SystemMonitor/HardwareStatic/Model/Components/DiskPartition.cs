using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Interface;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class DiskPartition : HardwareStaticComponent, IHardwareStaticComponent<DiskPartition>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830524(v=vs.85).aspx
        public string DiskId { get; private set; }

        public string DiskNumber { get; private set; }

        public string DriveLetter { get; private set; }

        public string IsActive { get; private set; }

        public string IsBoot { get; private set; }

        public string IsHidden { get; private set; }

        public string IsOffline { get; private set; }

        public string IsReadOnly { get; private set; }

        public string IsShadowCopy { get; private set; }

        public string IsSystem { get; private set; }

        // See https://en.wikipedia.org/wiki/Partition_type#PID_00h
        public string MbrType { get; private set; }

        public string NoDefaultDriveLetter { get; private set; }

        public string ObjectId { get; private set; }

        public UnitValue Offset { get; private set; }

        public string PartitionNumber { get; private set; }

        public UnitValue Size { get; private set; }

        public List<DiskPartition> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<DiskPartition> staticData = new List<DiskPartition>();

            foreach (var managementObject in managementObjectList)
            {
                DiskPartition diskPartition = new DiskPartition();
                diskPartition.Caption = string.Empty;
                diskPartition.Description = string.Empty;
                diskPartition.DiskId = managementObject[ConstString.DISK_PARTITION_DISK_ID].TryGetStringValue();
                diskPartition.DiskNumber = managementObject[ConstString.DISK_PARTITION_DISK_NUMBER].TryGetStringValue();
                diskPartition.DriveLetter = managementObject[ConstString.DISK_PARTITION_DRIVE_LETTER].TryGetStringValue();
                diskPartition.IsActive = managementObject[ConstString.DISK_PARTITION_IS_ACTIVE].TryGetStringValue();
                diskPartition.IsBoot = managementObject[ConstString.DISK_PARTITION_IS_BOOT].TryGetStringValue();
                diskPartition.IsHidden = managementObject[ConstString.DISK_PARTITION_IS_HIDDEN].TryGetStringValue();
                diskPartition.IsOffline = managementObject[ConstString.DISK_PARTITION_IS_OFFLINE].TryGetStringValue();
                diskPartition.IsReadOnly = managementObject[ConstString.DISK_PARTITION_IS_READ_ONLY].TryGetStringValue();
                diskPartition.IsShadowCopy = managementObject[ConstString.DISK_PARTITION_IS_SHADOW_COPY].TryGetStringValue();
                diskPartition.IsSystem = managementObject[ConstString.DISK_PARTITION_IS_SYSTEM].TryGetStringValue();
                diskPartition.MbrType = managementObject[ConstString.DISK_PARTITION_MRB_TYPE].TryGetStringValue();
                diskPartition.Name = string.Empty;
                diskPartition.NoDefaultDriveLetter = managementObject[ConstString.DISK_PARTITION_NO_DEFAULT_DRIVE_LETTER].TryGetStringValue();
                diskPartition.ObjectId = managementObject[ConstString.DISK_PARTITION_OBJECT_ID].TryGetStringValue();
                diskPartition.Offset = managementObject[ConstString.DISK_PARTITION_OFFSET].TryGetUnitValue(Unit.B);
                diskPartition.PartitionNumber = managementObject[ConstString.DISK_PARTITION_PARTITION_NUMBER].TryGetStringValue();
                diskPartition.Size = managementObject[ConstString.DISK_PARTITION_SIZE].TryGetUnitValue(Unit.B);
                diskPartition.Status = string.Empty;

                staticData.Add(diskPartition);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstString.WMI_QUERY_DISK_PARTITION);
        }
    }
}
