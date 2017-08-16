using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Analyzed;

namespace SystemMonitor.HardwareStatic.Analyzer
{
    public interface IHardwareStaticAnalyzer
    {
        List<SMARTData> GetSmartData(List<SmartFailurePredictStatus> smartFailurePredictStatus, List<SmartFailurePredictData> smartFailurePredictData, List<SmartFailurePredictThresholds> smartFailurePredictThresholds);

        List<Storage> GetStorageData(List<Disk> disk, List<DiskPartition> diskPartition, List<Volume> volume, List<DiskToPartition> diskToPartition, List<PartitionToVolume> partitionToVolume);
    }
}
