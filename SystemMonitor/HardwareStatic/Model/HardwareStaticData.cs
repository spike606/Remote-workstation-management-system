using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Analyzed;

namespace SystemMonitor.HardwareStatic.Model
{
    public class HardwareStaticData
    {
        public List<ProcessorStatic> Processor { get; set; }

        public List<ProcessorCache> ProcessorCache { get; set; }

        public List<Memory> Memory { get; set; }

        public List<Disk> Disk { get; set; }

        public List<CDROMDrive> CDROMDrive { get; set; }

        public List<BaseBoard> BaseBoard { get; set; }

        public List<Fan> Fan { get; set; }

        public List<Battery> Battery { get; set; }

        public List<NetworkAdapter> NetworkAdapter { get; set; }

        public List<Printer> Printer { get; set; }

        public List<VideoController> VideoController { get; set; }

        public List<PnPEntity> PnPEntity { get; set; }

        public List<Volume> Volume { get; set; }

        public List<DiskPartition> DiskPartition { get; set; }

        public List<SmartFailurePredictData> SmartFailurePredictData { get; set; }

        public List<SmartFailurePredictStatus> SmartFailurePredictStatus { get; set; }

        public List<SmartFailurePredictThresholds> SmartFailurePredictThresholds { get; set; }

        public List<SMARTData> SMARTData { get; set; }

        public List<DiskToPartition> DiskToPartition { get; set; }

        public List<PartitionToVolume> PartitionToVolume { get; set; }

        public List<Storage> Storage { get; set; }
    }
}
