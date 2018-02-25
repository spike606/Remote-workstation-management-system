using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Analyzed;

namespace SystemManagament.Monitor.HardwareStatic.Analyzer
{
    public interface IHardwareStaticAnalyzer
    {
        List<SMARTData> GetSmartData(List<SmartFailurePredictStatus> smartFailurePredictStatuses, List<SmartFailurePredictData> smartFailurePredictDatas, List<SmartFailurePredictThresholds> smartFailurePredictThresholds);

        List<Storage> GetStorageData(List<Disk> disks, List<DiskPartition> diskPartitions, List<Volume> volumes, List<DiskToPartition> disksToPartitions, List<PartitionToVolume> partitionsToVolumes);
    }
}
