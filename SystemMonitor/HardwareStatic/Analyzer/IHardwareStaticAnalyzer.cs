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
        List<SMARTData> GetSmartData(List<HardwareComponent> smartFailurePredictStatus, List<HardwareComponent> smartFailurePredictData, List<HardwareComponent> smartFailurePredictThresholds);

        List<Storage> GetStorageData(List<HardwareComponent> diskList, List<HardwareComponent> diskPartitionList, List<HardwareComponent> volumeList, List<HardwareComponent> diskToPartitionList, List<HardwareComponent> partitionToVolumeList);
    }
}
