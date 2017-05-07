using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Processor
    {
        public string Name { get; set; }

        public UnitValue AddressWidth { get; set; }
    }
}
