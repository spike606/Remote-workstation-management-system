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

        public List<Memory> Memory { get; set; }

        public List<DiskDrive> DiskDrive { get; set; }

        public List<LogicalDisk> LogicalDisk { get; set; }

        public List<CDROMDrive> CDROMDrive { get; set; }

        public List<BaseBoard> BaseBoard { get; set; }

        public List<Fan> Fan { get; set; }

        public List<Battery> Battery { get; set; }

        public List<NetworkAdapter> NetworkAdapter { get; set; }

        public List<Printer> Printer { get; set; }

        public List<VideoController> VideoController { get; set; }
    }
}
