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
    public class DiskPartition : HardwareComponent
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

        public UnitValue Offset { get; private set; }

        public string PartitionNumber { get; private set; }

        public UnitValue Size { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            DiskPartition diskPartition = new DiskPartition();
            diskPartition.Caption = string.Empty;
            diskPartition.Description = string.Empty;
            diskPartition.DiskId = managementObject[ConstStringHardwareStatic.DISK_PARTITION_DISK_ID]?.ToString() ?? string.Empty;
            diskPartition.DiskNumber = managementObject[ConstStringHardwareStatic.DISK_PARTITION_DISK_NUMBER]?.ToString() ?? string.Empty;
            diskPartition.DriveLetter = managementObject[ConstStringHardwareStatic.DISK_PARTITION_DRIVE_LETTER]?.ToString() ?? string.Empty;
            diskPartition.IsActive = managementObject[ConstStringHardwareStatic.DISK_PARTITION_IS_ACTIVE]?.ToString() ?? string.Empty;
            diskPartition.IsBoot = managementObject[ConstStringHardwareStatic.DISK_PARTITION_IS_BOOT]?.ToString() ?? string.Empty;
            diskPartition.IsHidden = managementObject[ConstStringHardwareStatic.DISK_PARTITION_IS_HIDDEN]?.ToString() ?? string.Empty;
            diskPartition.IsOffline = managementObject[ConstStringHardwareStatic.DISK_PARTITION_IS_OFFLINE]?.ToString() ?? string.Empty;
            diskPartition.IsReadOnly = managementObject[ConstStringHardwareStatic.DISK_PARTITION_IS_READ_ONLY]?.ToString() ?? string.Empty;
            diskPartition.IsShadowCopy = managementObject[ConstStringHardwareStatic.DISK_PARTITION_IS_SHADOW_COPY]?.ToString() ?? string.Empty;
            diskPartition.IsSystem = managementObject[ConstStringHardwareStatic.DISK_PARTITION_IS_SYSTEM]?.ToString() ?? string.Empty;
            diskPartition.MbrType = managementObject[ConstStringHardwareStatic.DISK_PARTITION_MRB_TYPE]?.ToString() ?? string.Empty;
            diskPartition.Name = string.Empty;
            diskPartition.NoDefaultDriveLetter = managementObject[ConstStringHardwareStatic.DISK_PARTITION_NO_DEFAULT_DRIVE_LETTER]?.ToString() ?? string.Empty;
            diskPartition.Offset = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.DISK_PARTITION_OFFSET]?.ToString() ?? string.Empty);
            diskPartition.PartitionNumber = managementObject[ConstStringHardwareStatic.DISK_PARTITION_PARTITION_NUMBER]?.ToString() ?? string.Empty;
            diskPartition.Size = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.DISK_PARTITION_SIZE]?.ToString() ?? string.Empty);
            diskPartition.Status = string.Empty;
            return diskPartition;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstStringHardwareStatic.WMI_QUERY_DISK_PARTITION);
        }
    }
}
