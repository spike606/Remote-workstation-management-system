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
        List<SMARTData> GetSmartData(List<HardwareComponent> smartFailurePredictStatus, List<HardwareComponent> smartFailurePredictData, List<HardwareComponent> smartFailurePredictTresholds);

        List<Storage> GetStorageData(Disk disk, DiskPartition diskPartition, Volume volume, DiskToPartition diskToPartition, PartitionToVolume partitionToVolume);
    }
}
