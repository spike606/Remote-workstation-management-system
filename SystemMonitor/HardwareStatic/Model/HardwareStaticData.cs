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
        public List<HardwareStaticComponent> Processor { get; set; }

        public List<HardwareStaticComponent> ProcessorCache { get; set; }

        public List<HardwareStaticComponent> Memory { get; set; }

        public List<HardwareStaticComponent> Disk { get; set; }

        public List<HardwareStaticComponent> CDROMDrive { get; set; }

        public List<HardwareStaticComponent> BaseBoard { get; set; }

        public List<HardwareStaticComponent> Fan { get; set; }

        public List<HardwareStaticComponent> Battery { get; set; }

        public List<HardwareStaticComponent> NetworkAdapter { get; set; }

        public List<HardwareStaticComponent> Printer { get; set; }

        public List<HardwareStaticComponent> VideoController { get; set; }

        public List<HardwareStaticComponent> PnPEntity { get; set; }

        public List<HardwareStaticComponent> Volume { get; set; }

        public List<HardwareStaticComponent> DiskPartition { get; set; }

        public List<HardwareStaticComponent> SmartFailurePredictData { get; set; }

        public List<HardwareStaticComponent> SmartFailurePredictStatus { get; set; }

        public List<HardwareStaticComponent> SmartFailurePredictThresholds { get; set; }

        public List<SMARTData> SMARTData { get; set; }

        public List<HardwareStaticComponent> DiskToPartition { get; set; }

        public List<HardwareStaticComponent> PartitionToVolume { get; set; }

        public List<Storage> Storage { get; set; }
    }
}
