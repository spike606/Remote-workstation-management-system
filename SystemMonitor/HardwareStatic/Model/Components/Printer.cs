using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Printer
    {
        public string AveragePagesPerMinute { get; set; }

        public string Caption { get; set; }

        public string Default { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string Name { get; set; }

        public string PortName { get; set; }

        public string PrintProcessor { get; set; }
    }
}
