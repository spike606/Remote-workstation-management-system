using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;

namespace SystemMonitor.HardwareStatic.Model.Components.Analyzed
{
    public class Storage
    {
        public Storage(Disk disk)
        {
            this.Disk = disk;
        }

        public Disk Disk { get; set; }

        public List<LogicalPartition> Partition { get; set; } = new List<LogicalPartition>();
    }
}
