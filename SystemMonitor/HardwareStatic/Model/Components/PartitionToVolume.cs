using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Interface;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class PartitionToVolume : HardwareStaticComponent, IHardwareStaticComponent<PartitionToVolume>
    {
        public string Partition { get; set; }

        public string Volume { get; set; }

        public List<PartitionToVolume> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<PartitionToVolume> staticData = new List<PartitionToVolume>();

            foreach (var managementObject in managementObjectList)
            {
                PartitionToVolume partitionToVolume = new PartitionToVolume();
                partitionToVolume.Caption = string.Empty;
                partitionToVolume.Description = string.Empty;
                partitionToVolume.Partition = managementObject[ConstString.PARTITION_TO_VOLUME_PARTITION].TryGetStringValue();
                partitionToVolume.Name = string.Empty;
                partitionToVolume.Volume = managementObject[ConstString.PARTITION_TO_VOLUME_VOLUME].TryGetStringValue();
                partitionToVolume.Status = string.Empty;

                staticData.Add(partitionToVolume);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstString.WMI_QUERY_PARTITION_TO_VOLUME);
        }
    }
}
