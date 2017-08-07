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
        List<SMARTData> GetSmartData(List<HardwareStaticComponent> smartFailurePredictStatus, List<HardwareStaticComponent> smartFailurePredictData, List<HardwareStaticComponent> smartFailurePredictThresholds);

        List<Storage> GetStorageData(List<HardwareStaticComponent> diskList, List<HardwareStaticComponent> diskPartitionList, List<HardwareStaticComponent> volumeList, List<HardwareStaticComponent> diskToPartitionList, List<HardwareStaticComponent> partitionToVolumeList);
    }
}
