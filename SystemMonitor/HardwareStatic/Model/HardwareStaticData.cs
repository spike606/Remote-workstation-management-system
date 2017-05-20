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
    }
}
