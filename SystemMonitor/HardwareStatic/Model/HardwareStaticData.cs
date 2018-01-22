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

        public List<CDROMDrive> CDROMDrive { get; set; }

        public List<BaseBoard> BaseBoard { get; set; }

        public List<Fan> Fan { get; set; }

        public List<Battery> Battery { get; set; }

        public List<NetworkAdapter> NetworkAdapter { get; set; }

        public List<Printer> Printer { get; set; }

        public List<VideoController> VideoController { get; set; }

        public List<PnPEntity> PnPEntity { get; set; }

        public List<SMARTData> SMARTData { get; set; }

        public List<Storage> Storage { get; set; }

        internal List<Disk> Disk { get; set; }

        internal List<Volume> Volume { get; set; }

        internal List<DiskPartition> DiskPartition { get; set; }

        internal List<SmartFailurePredictData> SmartFailurePredictData { get; set; }

        internal List<SmartFailurePredictStatus> SmartFailurePredictStatus { get; set; }

        internal List<SmartFailurePredictThresholds> SmartFailurePredictThresholds { get; set; }

        internal List<DiskToPartition> DiskToPartition { get; set; }

        internal List<PartitionToVolume> PartitionToVolume { get; set; }
    }
}
