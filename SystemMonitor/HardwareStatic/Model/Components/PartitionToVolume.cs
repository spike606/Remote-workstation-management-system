﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class PartitionToVolume : HardwareStaticComponent
    {
        public string Partition { get; set; }

        public string Volume { get; set; }

        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            PartitionToVolume partitionToVolume = new PartitionToVolume();
            partitionToVolume.Caption = string.Empty;
            partitionToVolume.Description = string.Empty;
            partitionToVolume.Partition = managementObject[ConstString.PARTITION_TO_VOLUME_PARTITION]?.ToString() ?? string.Empty;
            partitionToVolume.Name = string.Empty;
            partitionToVolume.Volume = managementObject[ConstString.PARTITION_TO_VOLUME_VOLUME]?.ToString() ?? string.Empty;
            partitionToVolume.Status = string.Empty;
            return partitionToVolume;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstString.WMI_QUERY_PARTITION_TO_VOLUME);
        }
    }
}