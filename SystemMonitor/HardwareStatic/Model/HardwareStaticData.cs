using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;

namespace SystemMonitor.HardwareStatic.Model
{
    public class HardwareStaticData
    {
        public Processor Processor { get; set; }

        public List<IHardwareComponent> Memory { get; set; }

        public List<IHardwareComponent> DiskDrive { get; set; }

        public List<IHardwareComponent> LogicalDisk { get; set; }

        public List<IHardwareComponent> CDROMDrive { get; set; }

        public List<IHardwareComponent> BaseBoard { get; set; }

        public List<IHardwareComponent> Fan { get; set; }

        public List<IHardwareComponent> Battery { get; set; }

        public List<IHardwareComponent> NetworkAdapter { get; set; }

        public List<IHardwareComponent> Printer { get; set; }

        public List<IHardwareComponent> VideoController { get; set; }

        public List<IHardwareComponent> PnPEntity { get; set; }

        public List<IHardwareComponent> Volume { get; set; }
    }
}
