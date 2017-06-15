using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;

namespace SystemMonitor.HardwareStatic.Model
{
    public class HardwareStaticData
    {
        public List<HardwareComponent> Processor { get; set; }

        public List<HardwareComponent> ProcessorCache { get; set; }

        public List<HardwareComponent> Memory { get; set; }

        public List<HardwareComponent> Disk { get; set; }

        public List<HardwareComponent> CDROMDrive { get; set; }

        public List<HardwareComponent> BaseBoard { get; set; }

        public List<HardwareComponent> Fan { get; set; }

        public List<HardwareComponent> Battery { get; set; }

        public List<HardwareComponent> NetworkAdapter { get; set; }

        public List<HardwareComponent> Printer { get; set; }

        public List<HardwareComponent> VideoController { get; set; }

        public List<HardwareComponent> PnPEntity { get; set; }

        public List<HardwareComponent> Volume { get; set; }

        public List<HardwareComponent> DiskPartition { get; set; }
    }
}
