using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class DiskToPartition : HardwareStaticComponent
    {
        public string Disk { get; set; }

        public string Partition { get; set; }

        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            DiskToPartition diskToPartition = new DiskToPartition();
            diskToPartition.Caption = string.Empty;
            diskToPartition.Description = string.Empty;
            diskToPartition.Disk = managementObject[ConstString.DISK_TO_PARTITION_DISK]?.ToString() ?? string.Empty;
            diskToPartition.Name = string.Empty;
            diskToPartition.Partition = managementObject[ConstString.DISK_TO_PARTITION_PARTITION]?.ToString() ?? string.Empty;
            diskToPartition.Status = string.Empty;
            return diskToPartition;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstString.WMI_QUERY_DISK_TO_PARTITION);
        }
    }
}
